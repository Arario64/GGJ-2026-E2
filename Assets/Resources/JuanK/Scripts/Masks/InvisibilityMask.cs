using UnityEngine;

public class InvisibilityMask : Mask
{

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public override bool Activate()
  {
    if (!base.Activate())
    {
      return false;
    }

    Player player = GameManager.Instance.Player;

    Color invisibleColor = player.SpriteRen.color;
    invisibleColor.a = 0.5f;
    player.SpriteRen.color = invisibleColor;

    player.IsInvisible = true;

    return true;
  }
}
