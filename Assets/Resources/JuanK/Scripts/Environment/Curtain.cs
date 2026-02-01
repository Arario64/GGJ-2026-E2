using UnityEngine;

public class Curtain : MonoBehaviour
{
  [SerializeField] private Sprite m_curtainSprite;
  [SerializeField] private Sprite m_burnedCurtainSprite;

  SpriteRenderer m_spriteRen;

  private bool m_isBurning = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_spriteRen = GetComponentInChildren<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (m_isBurning)
    {
      m_spriteRen.sprite = m_burnedCurtainSprite;
      Destroy(gameObject, 1.0f);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if ((collision.CompareTag("Fire") || collision.CompareTag("Explotion")))
    {
      m_isBurning = true;
    }
  }

}
