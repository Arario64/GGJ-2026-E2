using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
  private BoxCollider2D m_wallCollider;
  private SpriteRenderer m_spriteRen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_wallCollider = GetComponent<BoxCollider2D>();
    m_spriteRen = GetComponentInChildren<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void Destroy()
  {
    m_wallCollider.enabled = false;
    Color color = m_spriteRen.color;
    color.a = 0.2f;
    m_spriteRen.color = color;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Explotion"))
    {
      Destroy();
    }
  }


}
