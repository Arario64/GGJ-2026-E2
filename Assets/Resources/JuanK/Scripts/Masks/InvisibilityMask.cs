using UnityEngine;

public class InvisibilityMask : Mask
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

    Player player = GameManager.Instance.Player;

    Color invisibleColor = player.SpriteRen.color;
    invisibleColor.a = 0.5f;
    player.SpriteRen.color = invisibleColor;

    player.IsInvisible = true;
    m_active = true;

    return true;
  }

  public override void Deactivate()
  {
    Player player = GameManager.Instance.Player;

    Color invisibleColor = player.SpriteRen.color;
    invisibleColor.a = 1.0f;
    player.SpriteRen.color = invisibleColor;

    player.IsInvisible = false;

    m_active = false;
  }
}
