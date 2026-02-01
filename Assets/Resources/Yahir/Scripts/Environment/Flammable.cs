using UnityEngine;

public class Flammable : MonoBehaviour
{
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
    if (collision.CompareTag("Fire"))
    {
      Destroy(gameObject);
    }
  }

  public void OnDestroy()
  {
    Destroy(gameObject);
  }


}
