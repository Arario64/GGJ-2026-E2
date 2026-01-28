using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
  public event Action<bool> OnSeeingTruth;

  #region Members

  private FSM m_FSM;
  private PlayerIdleState m_idleState;
  private PlayerMoveState m_moveState;

  [SerializeField] private float m_moveSpeed = 5.0f;
  private Vector2 m_movingDir;

  private SpriteRenderer m_spriteRen;

  private List<Mask> m_masks = new();
  private int m_currMask;

  private bool m_isInvisible = false;
  private bool m_isSeeingTruth = false;

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

  public bool IsInvisible
  {
    get { return m_isInvisible; }
    set { m_isInvisible = value; }
  }

  public bool IsSeeingTruth
  {
    get { return m_isSeeingTruth; }
    set
    {
      m_isSeeingTruth = value;
      OnSeeingTruth?.Invoke(m_isSeeingTruth);
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
    InputActions.Playing.ActivateMask.performed += OnActivateMask;

    TruthSeerMask seerMask = ScriptableObject.CreateInstance<TruthSeerMask>();
    InvisibilityMask invMask = ScriptableObject.CreateInstance<InvisibilityMask>();
    m_masks.Add(seerMask);
    m_masks.Add(invMask);
    //m_masks[0].Activate();
  }


  private void OnDisable()
  {
    InputActions.Playing.Move.performed -= OnMoveInput;
    InputActions.Playing.Move.canceled -= OnCancelMoveInput;
    InputActions.Playing.ActivateMask.performed -= OnActivateMask;
  }

  private void OnMoveInput(InputAction.CallbackContext context)
  {
    m_movingDir = context.ReadValue<Vector2>();
  }

  private void OnCancelMoveInput(InputAction.CallbackContext context)
  {
    m_movingDir = Vector2.zero;
  }

  private void OnActivateMask(InputAction.CallbackContext context)
  {
    Mask mask = m_masks[m_currMask];

    if (mask)
    {
      mask.Activate();
    }
  }

  private void OnDeactivateMask(InputAction.CallbackContext context)
  {
    Mask mask = m_masks[m_currMask];

    if (mask)
    {
      mask.Deactivate();
    }
  }

  // Update is called once per frame
  void Update()
  {
    StateMachine.Update();
  }
}
