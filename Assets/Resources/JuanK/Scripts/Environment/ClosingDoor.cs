using UnityEngine;

public class ClosingDoor : MonoBehaviour
{
  [SerializeField] Sprite m_openDoor;
  [SerializeField] Sprite m_closeDoor;

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

    m_spriteRen.sprite = m_openDoor;
  }

  private void CloseDoor()
  {
    m_doorCollider.enabled = true;

    m_spriteRen.sprite = m_closeDoor;
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
