using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
  #region Members

  private FSM m_FSM;
  private PlayerIdleState m_idleState;
  private PlayerMoveState m_moveState;

  [SerializeField] private float m_moveSpeed = 5.0f;
  private Vector2 m_movingDir;

  private SpriteRenderer m_spriteRen;

  private List<Mask> m_masks = new();

  #endregion Members

  #region Getters / Setters

  public FSM StateMachine
  {
    get
    {
      m_FSM ??= new FSM();
      return m_FSM;
    }
  }

  public IState IdleState
  {
    get {
      if (m_idleState == null)
      {
        m_idleState = new PlayerIdleState();
        m_idleState.SetOwner(this);
      }
      return m_idleState;
    }
  }

  public IState MoveState
  {
    get {
      if (m_moveState == null)
      {
        m_moveState = new PlayerMoveState();
        m_moveState.SetOwner(this);
      }
      return m_moveState;
    }
  }

  public Vector2 MovingDir
  {
    get { return m_movingDir; }
  }

  public float MoveSpeed
  {
    get { return m_moveSpeed; }
  }

  public SpriteRenderer SpriteRen
  {
    get {
      if (m_spriteRen == null)
      {
        m_spriteRen = gameObject.GetComponent<SpriteRenderer>();
      }
      return m_spriteRen;
    }
  }

  public IA_Player InputActions
  {
    get { return GameManager.Instance.InputActions; }
  }

  #endregion Getters / Setters

  private void Awake()
  {

  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    CustomAssert.IsNotNull(StateMachine);
    CustomAssert.IsNotNull(IdleState);
    CustomAssert.IsNotNull(MoveState);

    StateMachine.Init(IdleState);

    InputActions.Playing.Move.performed += OnMoveInput;
    InputActions.Playing.Move.canceled += OnCancelMoveInput;

    InvisibilityMask invMask = ScriptableObject.CreateInstance<InvisibilityMask>();
    m_masks.Add(invMask);
    m_masks[0].Activate();
  }


  private void OnDisable()
  {
    InputActions.Playing.Move.performed -= OnMoveInput;
  }

  private void OnMoveInput(InputAction.CallbackContext context)
  {
    m_movingDir = context.ReadValue<Vector2>();
  }

  private void OnCancelMoveInput(InputAction.CallbackContext context)
  {
    m_movingDir = Vector2.zero;
  }

  // Update is called once per frame
  void Update()
  {
    StateMachine.Update();
  }
}
