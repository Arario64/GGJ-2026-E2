using UnityEngine;

public class Mask : MonoBehaviour
{

  [SerializeField] private float m_maxPower;
  [SerializeField] private float m_useCost;
  [SerializeField] private bool m_isFreeToUse = false;
  private float m_currPower;

  public virtual bool Activate()
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
    if (m_currPower <= 0.0f)
    {
      m_currPower = 0.0f;
      return false;
    }
    // Power is consumed
    m_currPower -= m_useCost;
    return true;
  }

  public virtual void Deactivate()
  {
    // To be overridden
  }
}
