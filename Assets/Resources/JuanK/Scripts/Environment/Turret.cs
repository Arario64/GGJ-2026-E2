using UnityEngine;

public class Turret : MonoBehaviour
{
  private SpriteRenderer SpriteRen;
  private Color OGColor;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    SpriteRen = GetComponent<SpriteRenderer>();
    OGColor = SpriteRen.color;
  }

  // Update is called once per frame
  void Update()
  {

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
    //Just visual function for now
    SpriteRen.color = Color.red;
  }

  private void StopAttacking()
  {
    //Just visual function for now
    SpriteRen.color = OGColor;
  }
}
