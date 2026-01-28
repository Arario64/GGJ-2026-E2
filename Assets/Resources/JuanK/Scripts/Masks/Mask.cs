using UnityEngine;

public class Mask : ScriptableObject
{

  [SerializeField] private float m_maxPower;
  [SerializeField] private float m_useCost;
  private float m_currPower;



  public virtual void Activate()
  {
    // Check if power can be used
    if (m_currPower < m_useCost)
    {
      return;
    }
    // Power is consumed
    m_currPower -= m_useCost;
  }

  public virtual void Deactivate()
  {
    // To be overridden
  }
}
