using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
  public event Action OnLit;
  public event Action OnUnlit;

  [SerializeField] private float m_lifetime = 5.0f;

  [Tooltip("Torch won't unlit for time passing")]
  [SerializeField] private bool m_foreverLit = false;
  private float m_litTime = 0.0f;
  private bool m_isLit = false;

  SpriteRenderer m_spriteRen;

  public bool IsForeverLit
  {
    get { return m_foreverLit; }
    set { m_foreverLit = value; }
  }

  public bool IsLit
  {
    get { return m_isLit; }
  }

  public SpriteRenderer SpriteRen
  {
    get
    {
      if (m_spriteRen == null)
      {
        m_spriteRen = GetComponent<SpriteRenderer>();
      }
      return m_spriteRen;
    }
  }

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

  public void Lit()
  {
    m_isLit = true;
    SpriteRen.color = Color.red;
    OnLit?.Invoke();
  }

  public void Unlit()
  {
    m_isLit = false;
    SpriteRen.color = Color.white;
    OnUnlit?.Invoke();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Fire") || collision.CompareTag("Explotion"))
    {
      if (!m_isLit)
      {
        Lit();
      }
    }

    if (collision.CompareTag("Ice"))
    {
      if (m_isLit)
      {
        Unlit();
      }
    }
  }

}
