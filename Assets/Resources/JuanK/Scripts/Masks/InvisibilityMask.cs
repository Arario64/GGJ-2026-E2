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

  public override void Activate()
  {
    base.Activate();

    Color invisibleColor = GameManager.Instance.Player.SpriteRen.color;
    invisibleColor.a = 0.5f;
    GameManager.Instance.Player.SpriteRen.color = invisibleColor;
  }
}
