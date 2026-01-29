using UnityEngine;

public class TeleportMask : Mask
{
  

  public override bool Activate()
  {
    Player player = GameManager.Instance.Player;

    if (player.TouchingWarp == null)
    {
      return false;
    }

    if (!base.Activate())
    {
      return false;
    }

    player.CanTeleport = true;

    return true;
  }

  public override void Deactivate()
  {
    GameManager.Instance.Player.CanTeleport = false;
  }

}
