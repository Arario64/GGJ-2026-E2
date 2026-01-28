using UnityEngine;

public class TruthSeerMask : Mask
{
  bool m_active = false;

  private void Update()
  {
    if (m_active)
    {
      Debug.Log(m_currPower);
      if (!Activate())
      {
        Deactivate();
      }
    }
  }

  public override bool Activate()
  {
    if (!base.Activate())
    {
      return false;
    }

    GameManager.Instance.Player.IsSeeingTruth = true;
    m_active = true;

    return true;
  }

  public override void Deactivate()
  {
    GameManager.Instance.Player.IsSeeingTruth = false;
    m_active = false;
  }
}
