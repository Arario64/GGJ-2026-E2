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

  protected virtual void Start()
  {
    m_currPower = m_maxPower;
    OnPowerChange?.Invoke(this);
  }

  protected virtual void Update()
  {
    // Recharge power
    if (m_currPower < m_maxPower)
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
