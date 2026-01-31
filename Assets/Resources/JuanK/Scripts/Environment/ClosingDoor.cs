using UnityEngine;

public class ClosingDoor : MonoBehaviour
{
  private BoxCollider2D m_doorCollider;
  private SpriteRenderer m_spriteRen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_doorCollider = GetComponent<BoxCollider2D>();
    m_spriteRen = GetComponent<SpriteRenderer>();
    OpenDoor();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OpenDoor()
  {
    m_doorCollider.enabled = false;

    Color color = m_spriteRen.color;
    color.a = 0.2f;
    m_spriteRen.color = color;
  }

  private void CloseDoor()
  {
    m_doorCollider.enabled = true;

    Color color = m_spriteRen.color;
    color.a = 1.0f;
    m_spriteRen.color = color;
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      if (GameManager.Instance.Player.IsInvisible)
      {
        OpenDoor();
      }
      else
      {
        CloseDoor();
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      OpenDoor();
    }
  }
}
