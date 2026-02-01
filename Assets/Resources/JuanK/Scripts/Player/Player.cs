using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public event Action<bool> OnSeeingTruth;

  #region Members

  private FSM m_FSM;
  private PlayerIdleState m_idleState;
  private PlayerMoveState m_moveState;

  [SerializeField] private float m_moveSpeed = 5.0f;
  private Vector2 m_movingDir;
  private Vector2 m_lastMovingDir;

  private Rigidbody2D m_rb;
  private SpriteRenderer m_spriteRen;

  private List<Mask> m_masks = new();
  private int m_currMask;

  private bool m_isInvisible = false;
  private bool m_isSeeingTruth = false;
  private bool m_canTeleport = false;

  private int m_keysCollected = 0;

  private Vector2 m_lastCheckpoint;
  Warp m_touchingWarp;

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

  public Vector2 LastMovingDir
  {
    get { return m_lastMovingDir; }
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
        m_spriteRen = GetComponentInChildren<SpriteRenderer>();
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

  public Mask CurrMask
  {
    get
    {
      int count = m_masks.Count;
      if (m_currMask >= 0 && m_currMask < count)
      {
        return m_masks[m_currMask];
      }
      return null;
    }
  }

  public int KeysCollected
  {
    get { return m_keysCollected; }
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

  public Warp TouchingWarp
  {
    get { return m_touchingWarp; }
  }

  public IA_Player InputActions
  {
    get { return GameManager.Instance.InputActions; }
  }

  public Vector2 LastCheckpoint
  {
    get { return m_lastCheckpoint; }
    set { m_lastCheckpoint = value; }
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
    InputActions.Playing.InventoryKeyboard.performed += OnInventoryKeyboard;
    InputActions.Playing.InventoryMousewheel.performed += OnInventoryInputMouse;

    LastCheckpoint = transform.position;

    //GameManager.Instance.UI.UpdateKeysText(m_keysCollected);
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
    m_lastMovingDir = m_movingDir;
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

  private void OnInventoryKeyboard(InputAction.CallbackContext context)
  {
    if (!context.performed) return;
    
    int slot = (int)context.ReadValue<float>() - 1;
    int count = m_masks.Count;
    if (slot >= 0 && slot < count)
    {
      if (slot != m_currMask)
      {
        // Deactivate current mask
        Mask currMask = CurrMask;
        if (currMask != null && currMask.IsActive)
        {
          currMask.Deactivate();
          m_currMask = slot;
          m_masks[m_currMask].Activate();
          GameManager.Instance.UI.UpdateMaskPower(m_masks[m_currMask]);
          return;
        }
      }

      m_currMask = slot;
      GameManager.Instance.UI.UpdateMaskPower(m_masks[m_currMask]);
    }

  }

  void OnInventoryInputMouse(InputAction.CallbackContext context)
  {
    if (!context.performed) return;
    float scrollValue = context.ReadValue<float>();
    int count = m_masks.Count;
    if (count == 0 || count == 1) return;
    Mask mask = CurrMask;
    bool activateNext = false;
    if (scrollValue > 0)
    {
      if (mask != null && mask.IsActive)
      {
        mask.Deactivate();
        activateNext = true;
      }
      m_currMask--;
      if (m_currMask < 0)
      {
        m_currMask = count - 1;
      }
    }
    else if (scrollValue < 0)
    {
      if (mask != null && mask.IsActive)
      {
        mask.Deactivate();
        activateNext = true;
      }
      m_currMask++;
      if (m_currMask >= count)
      {
        m_currMask = 0;
      }
    }
    GameManager.Instance.UI.UpdateMaskPower(m_masks[m_currMask]);
    if (activateNext)
    {
      m_masks[m_currMask].Activate();
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
        m_currMask = m_masks.Count - 1;
        GameManager.Instance.UI.AddMaskToInventory(mask, m_currMask == 0);
        mask.transform.parent = transform;
        mask.transform.localPosition = Vector3.zero;
        mask.SpriteRen.enabled = false;
        mask.Collider.enabled = false;
      }
    }

    if (collision.CompareTag("Warp"))
    {
      Warp warp = collision.GetComponent<Warp>();
      if (warp)
      {
        m_touchingWarp = warp;
      }
    }

    if (collision.CompareTag("Checkpoint"))
    {
      LastCheckpoint = collision.transform.position;
    }

    if (collision.CompareTag("Key"))
    {
      Destroy(collision.gameObject);
      m_keysCollected++;
      //GameManager.Instance.UI.UpdateKeysText(m_keysCollected);
    }

    if (collision.CompareTag("Hazard") || collision.CompareTag("Explotion"))
    {
      //TODO: Check if create a death state with animation
      transform.position = LastCheckpoint;
    }

  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.CompareTag("Abyss"))
    {
      WaterIceAbyss waterIce = collision.GetComponent<WaterIceAbyss>();
      if (waterIce && !waterIce.IsFrozen)
      {
        transform.position = LastCheckpoint;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Warp"))
    {
      Warp warp = collision.GetComponent<Warp>();
      if (warp && warp == m_touchingWarp)
      {
        m_touchingWarp = null;
      }
    }
  }

  
}
