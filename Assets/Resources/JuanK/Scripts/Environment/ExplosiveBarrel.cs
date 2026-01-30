using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
  [SerializeField] private float m_explosionTimer = 2.5f;

  SpriteRenderer m_spriteRen;
  CircleCollider2D m_explotionCollider;

  private float m_timer = 0.0f;
  private bool m_isGoingToExplode = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_spriteRen = GetComponent<SpriteRenderer>();
    m_explotionCollider = GetComponentInChildren<CircleCollider2D>();

    m_explotionCollider.enabled = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (m_isGoingToExplode)
    {
      float time = Time.deltaTime;
      m_timer += time;
      if (m_timer >= m_explosionTimer)
      {
        m_explotionCollider.enabled = true;
        //TODO: Replace the timed destroy with an animation
        //Destroy(gameObject);
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if ((collision.CompareTag("Fire") || collision.CompareTag("Explotion")) && !m_isGoingToExplode)
    {
      m_isGoingToExplode = true;
      m_spriteRen.color = Color.red;
    }
  }

}
