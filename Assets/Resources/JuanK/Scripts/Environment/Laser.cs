using UnityEngine;

public class Laser : MonoBehaviour
{
  [SerializeField] private float m_speed = 10.0f;
  [SerializeField] private float m_lifeTime = 5.0f;

  private Vector2 m_direction = Vector2.zero;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    
  }

  public void SetDirection(Vector2 direction)
  {
    m_direction = direction.normalized;
  }

  // Update is called once per frame
  void Update()
  {
    float time = Time.deltaTime;

    transform.position += new Vector3(m_direction.x * m_speed * time, m_direction.y * m_speed * time, 0.0f);
    m_lifeTime -= time;
    if (m_lifeTime <= 0.0f)
    {
      Destroy(gameObject);
    }
  }
}
