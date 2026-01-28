using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InvisibleObject : MonoBehaviour
{
  private SpriteRenderer m_spriteRen;

  public SpriteRenderer SpriteRen
  {
    get
    {
      if (m_spriteRen == null)
      {
        m_spriteRen = gameObject.GetComponent<SpriteRenderer>();
      }
      return m_spriteRen;
    }
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    ToggleVisibility(GameManager.Instance.Player.IsSeeingTruth);
    GameManager.Instance.Player.OnSeeingTruth += ToggleVisibility;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void ToggleVisibility(bool isVisible)
  {
    SpriteRen.enabled = isVisible;
  }
}
