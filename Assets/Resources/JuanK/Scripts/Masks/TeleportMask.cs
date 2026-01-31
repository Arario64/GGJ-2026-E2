using UnityEngine;

public class TeleportMask : Mask
{
  protected override void Start()
  {
    m_type = MaskTypes.TELEPORT;
    base.Start();
  }

  protected override void Update()
  {
    base.Update();
  }

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
