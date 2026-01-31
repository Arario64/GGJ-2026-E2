using UnityEngine;

public class InvisibilityMask : Mask
{
  [Tooltip("0 means full invisible and 1 full visible.")]
  [SerializeField, Range(0.0f, 1.0f)] float m_playerOpacity = 0.5f;

  protected override void Start()
  {
    m_type = MaskTypes.INVISIBILITY;
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

    Player player = GameManager.Instance.Player;

    Color invisibleColor = player.SpriteRen.color;
    invisibleColor.a = m_playerOpacity;
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
