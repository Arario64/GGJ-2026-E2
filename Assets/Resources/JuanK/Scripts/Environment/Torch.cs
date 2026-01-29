using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
  public event Action OnLit;
  public event Action OnUnlit;

  [SerializeField] private float m_lifetime = 5.0f;

  [Tooltip("Torch will never unlit")]
  [SerializeField] private bool m_foreverLit = false;
  private float m_litTime = 0.0f;
  private bool m_isLit = false;

  SpriteRenderer m_spriteRen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_spriteRen = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (m_isLit && !m_foreverLit)
    {
      float time = Time.deltaTime;

      m_litTime += time;
      if (m_litTime >= m_lifetime)
      {
        Unlit();
        m_litTime = 0.0f;
      }
    }
  }

  private void Lit()
  {
    m_isLit = true;
    m_spriteRen.color = Color.red;
    OnLit?.Invoke();
  }

  private void Unlit()
  {
    m_isLit = false;
    m_spriteRen.color = Color.white;
    OnUnlit?.Invoke();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Fire"))
    {
      if (!m_isLit)
      {
        Lit();
      }
    }
  }

}
