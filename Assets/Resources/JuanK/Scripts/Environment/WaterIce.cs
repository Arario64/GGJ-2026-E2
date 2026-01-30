using UnityEngine;

public class WaterIceAbyss : MonoBehaviour
{
  [SerializeField] Sprite m_abyssSprite;
  [SerializeField] bool m_isAbyss = false;

  [SerializeField] Sprite m_waterSprite;
  [SerializeField] Sprite m_iceSprite;
  [SerializeField] float m_meltingTimer = 10.0f;
  [SerializeField] private bool m_canMelt = true;

  SpriteRenderer m_spriteRen;

  private float m_timer = 0.0f;
  private bool m_isFrozen = false;

  public bool IsFrozen { get { return m_isFrozen; } }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_spriteRen = GetComponent<SpriteRenderer>();
    if (m_isAbyss)
    {
      m_spriteRen.sprite = m_abyssSprite;
      return;
    }

    m_spriteRen.sprite = m_waterSprite;
  }

  // Update is called once per frame
  void Update()
  {
    if (m_isAbyss)
    {
      return;
    }

    if (m_isFrozen && m_canMelt)
    {
      float time = Time.deltaTime;
      m_timer += time;
      if (m_timer >= m_meltingTimer)
      {
        m_spriteRen.sprite = m_waterSprite;
        m_isFrozen = false;
        m_timer = 0.0f;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (m_isAbyss)
    {
      return;
    }

    if (collision.CompareTag("Ice"))
    {
      m_isFrozen = true;
      m_spriteRen.sprite = m_iceSprite;
      m_timer = 0.0f;
    }
  }
}
