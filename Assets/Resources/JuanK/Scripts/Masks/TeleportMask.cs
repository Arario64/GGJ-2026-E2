using UnityEngine;

public class TeleportMask : Mask
{
  

  public override bool Activate()
  {
    if (!base.Activate())
    {
      return false;
    }

    GameManager.Instance.Player.CanTeleport = true;

    return true;
  }

  public override void Deactivate()
  {
    GameManager.Instance.Player.CanTeleport = false;
  }

}
