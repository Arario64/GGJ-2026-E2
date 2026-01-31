using UnityEngine;

public class WinZone : MonoBehaviour
{
  [SerializeField] private int m_keysNeeded = 5;

  public int KeysNeeded
  {
    get { return m_keysNeeded; }
  }

  private void Awake()
  {
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Player player = collision.GetComponent<Player>();
    if (player != null)
    {
      if (player.KeysCollected >= m_keysNeeded)
      {
        //TODO: Win Level
        GameManager.Instance.IsGameOver = true;
        GameManager.Instance.IsGameWon = true;
      }
      else
      {
        Debug.Log("You need more keys to win the level!");
      }
    }
  }
}
