using UnityEngine;

public class Turret : MonoBehaviour
{
  [SerializeField] private GameObject m_laserPrefab;
  [SerializeField] private float m_fireRate = 1.0f;
  private float m_nextFireTime = 0.0f;
  private bool m_isFiring = false;

  private SpriteRenderer SpriteRen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    SpriteRen = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (m_isFiring)
    {
      float time = Time.time;
      m_nextFireTime += Time.deltaTime;
      if (m_nextFireTime >= m_fireRate)
      {
        AudioManager.Instance.PlaySfx(SFXTag.Laser_01);
        Vector3 playerColliderPos = GameManager.Instance.Player.Collider.bounds.center;

        Vector2 direction = playerColliderPos - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);
        GameObject laserGO = Instantiate(m_laserPrefab, transform.position, rotation);
        Laser laser = laserGO.GetComponent<Laser>();
        if (laser != null)
        {
          laser.SetDirection(direction);
        }
        m_nextFireTime = 0.0f;
      }
    }
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      if (!GameManager.Instance.Player.IsInvisible)
      {
        Attack();
      }
      else
      {
        StopAttacking();
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      StopAttacking();
    }
  }

  private void Attack()
  {
    SpriteRen.color = new(1.0f, 0.5716981f, 0.5716981f, 1.0f);
    m_isFiring = true;
  }

  private void StopAttacking()
  {
    //Just visual function for now
    SpriteRen.color = Color.white;
    m_isFiring = false;
  }
}
