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

  private Rigidbody2D m_rb;
  private SpriteRenderer m_spriteRen;

  private List<Mask> m_masks = new();
  private int m_currMask;

  private bool m_isInvisible = false;
  private bool m_isSeeingTruth = false;
  private bool m_canTeleport = false;

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
        m_spriteRen = GetComponent<SpriteRenderer>();
      }
      return m_spriteRen;
    }
  }

  public Rigidbody2D RB
  {
    get
    {
      if (m_rb == null)
      {
        m_rb = GetComponent<Rigidbody2D>();
      }
      return m_rb;
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

  public bool CanTeleport
  {
    get { return m_canTeleport; }
    set { m_canTeleport = value; }
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
    CustomAssert.IsNotNull(SpriteRen);
    CustomAssert.IsNotNull(RB);

    StateMachine.Init(IdleState);

    InputActions.Playing.Move.performed += OnMoveInput;
    InputActions.Playing.Move.canceled += OnCancelMoveInput;
    InputActions.Playing.ActivateMask.performed += OnActivateMask;
    InputActions.Playing.ActivateMask.canceled += OnDeactivateMask;

    //TruthSeerMask seerMask = ScriptableObject.CreateInstance<TruthSeerMask>();
    //InvisibilityMask invMask = ScriptableObject.CreateInstance<InvisibilityMask>();
    //m_masks.Add(seerMask);
    //m_masks.Add(invMask);
    //m_masks[0].Activate();
  }


  private void OnDisable()
  {
    InputActions.Playing.Move.performed -= OnMoveInput;
    InputActions.Playing.Move.canceled -= OnCancelMoveInput;
    InputActions.Playing.ActivateMask.performed -= OnActivateMask;
    InputActions.Playing.ActivateMask.canceled -= OnDeactivateMask;
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
    int count = m_masks.Count;
    if (m_currMask >= 0 && m_currMask < count)
    {
      Mask mask = m_masks[m_currMask];
      mask.Activate();

    }
  }

  private void OnDeactivateMask(InputAction.CallbackContext context)
  {
    int count = m_masks.Count;
    if (m_currMask >= 0 && m_currMask < count)
    {
      Mask mask = m_masks[m_currMask];
      mask.Deactivate();

    }
  }

  // Update is called once per frame
  void Update()
  {
    StateMachine.Update();
    RB.WakeUp();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Mask"))
    {
      Mask mask = collision.GetComponent<Mask>();
      if (mask && !m_masks.Contains(mask))
      {
        m_masks.Add(mask);
        mask.transform.parent = transform;
        mask.GetComponent<SpriteRenderer>().enabled = false;
        mask.GetComponent<PolygonCollider2D>().enabled = false;
      }
    }
  }
}
