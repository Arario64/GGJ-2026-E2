using UnityEngine;

public class Warp : MonoBehaviour
{
  [SerializeField] private Warp m_destiny;


  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    CustomAssert.IsNotNull(m_destiny);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      Player player = GameManager.Instance.Player;
      if (player.CanTeleport)
      {
        player.transform.position = m_destiny.transform.position;
        player.CanTeleport = false;
      }
    }
  }

}
