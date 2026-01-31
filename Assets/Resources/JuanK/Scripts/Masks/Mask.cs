using System;
using UnityEngine;

public enum MaskTypes
{
  FIRE = 0,
  ICE,
  TRUTH,
  INVISIBILITY,
  TELEPORT
}

public class Mask : MonoBehaviour
{
  public event Action<Mask> OnPowerChange;

  [SerializeField] private float m_maxPower;
  [SerializeField] private float m_useCost;
  [SerializeField] protected float m_rechargeRate;

  [Tooltip("If true, the mask can be used without power cost")]
  [SerializeField] private bool m_isFreeToUse = false;

  [SerializeField] private Color m_color = Color.red;
  protected MaskTypes m_type;

  private SpriteRenderer m_spriteRen;
  private BoxCollider2D m_collider;

  protected float m_currPower;
  protected bool m_active = false;

  public MaskTypes Type
  {
    get { return m_type; }
  }

  public float MaxPower
  {
    get { return m_maxPower; }
  }

  public float CurrPower
  {
    get { return m_currPower; }
  }

  public Color MaskColor
  {
    get { return m_color; }
  }

  public bool IsActive
  {
    get { return m_active; }
  }

  public SpriteRenderer SpriteRen
  {
    get
    {
      if (m_spriteRen == null)
      {
        m_spriteRen = GetComponentInChildren<SpriteRenderer>();
      }
      return m_spriteRen;
    }
    set
    {
      m_spriteRen = value;
    }
  }

  public BoxCollider2D Collider
  {
    get
    {
      if (m_collider == null)
      {
        m_collider = GetComponentInChildren<BoxCollider2D>();
      }
      return m_collider;
    }
    set
    {
      m_collider = value;
    }
  }

  protected virtual void Start()
  {
    CustomAssert.IsNotNull(SpriteRen);
    CustomAssert.IsNotNull(Collider);

    m_currPower = m_maxPower;
    OnPowerChange?.Invoke(this);
  }

  protected virtual void Update()
  {
    // Recharge power
    if ((m_currPower < m_maxPower) && !m_active)
    {
      //Debug.Log($"Current Power: {m_currPower}");
      float time = Time.deltaTime;
      m_currPower += m_rechargeRate * time;
      if (m_currPower > m_maxPower)
      {
        m_currPower = m_maxPower;
      }
      OnPowerChange?.Invoke(this);
    }
  }

  private bool CanBeActivated()
  {
    if (m_isFreeToUse)
    {
      return true;
    }

    // Check if power can be used
    if (m_currPower < m_useCost)
    {
      return false;
    }

    return true;
  }

  public virtual bool Activate()
  {
    if (!CanBeActivated())
    {
      return false;
    }
    // Power is consumed
    m_currPower -= m_useCost;

    if (m_currPower <= 0.0f)
    {
      m_currPower = 0.0f;
    }
    OnPowerChange?.Invoke(this);
    return true;
  }

  public virtual void Deactivate()
  {
    // To be overridden
  }
}
