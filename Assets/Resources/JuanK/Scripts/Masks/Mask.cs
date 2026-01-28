using UnityEngine;

public class Mask : MonoBehaviour
{

  [SerializeField] private float m_maxPower;
  [SerializeField] private float m_useCost;

  [Tooltip("If true, the mask can be used without power cost")]
  [SerializeField] private bool m_isFreeToUse = false;
  protected float m_currPower;

  private void Start()
  {
    m_currPower = m_maxPower;
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
    return true;
  }

  public virtual void Deactivate()
  {
    // To be overridden
  }
}
