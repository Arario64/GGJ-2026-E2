using UnityEngine;

public class TruthSeerMask : Mask
{

  protected override void Start()
  {
    m_type = MaskTypes.TRUTH;
    base.Start();
  }

  protected override void Update()
  {
    base.Update();

    if (m_active)
    {
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
