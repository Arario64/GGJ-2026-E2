using UnityEngine;

public class TruthSeerMask : Mask
{
  bool m_active = false;

  public override bool Activate()
  {
    if (m_active)
    {
      Deactivate();
      return true;
    }

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
