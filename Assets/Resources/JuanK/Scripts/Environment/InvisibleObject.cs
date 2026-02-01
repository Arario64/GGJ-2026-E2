using UnityEngine;

public class InvisibleObject : MonoBehaviour
{
  [Tooltip("Set to true if this object should be invisible when the player is seeing the truth.")]
  [SerializeField] private bool m_isFake = false;

  private SpriteRenderer m_spriteRen;

  private Collider2D m_collider;

  public SpriteRenderer SpriteRen
  {
    get
    {
      if (m_spriteRen == null)
      {
        m_spriteRen = gameObject.GetComponentInChildren<SpriteRenderer>();
      }
      return m_spriteRen;
    }
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_collider = gameObject.GetComponentInChildren<Collider2D>();
    if (m_collider != null && m_isFake)
    {
      m_collider.enabled = false;
    }

    ToggleVisibility(GameManager.Instance.Player.IsSeeingTruth);
    GameManager.Instance.Player.OnSeeingTruth += ToggleVisibility;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void ToggleVisibility(bool isVisible)
  {
    if (m_isFake)
    {
      isVisible = !isVisible;
    }
    SpriteRen.enabled = isVisible;
  }
}
