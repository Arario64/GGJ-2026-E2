using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
  public event Action<bool> OnStateChange;
  public event Action OnLit;
  public event Action OnUnlit;

  [SerializeField] private bool m_starstLit = false;
  [SerializeField] private float m_lifetime = 5.0f;

  private float m_litTime = 0.0f;
  [Tooltip("Torch won't unlit for time passing")]
  [SerializeField] private bool m_foreverLit = false;
  [SerializeField] private bool m_conditionIsLit = true;
  private bool m_conditionFulfilled = false;

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

  public bool ConditionIsLit
  {
    get { return m_conditionIsLit; }
  }

  public bool ConditionFulfilled
  {
    get { return m_conditionFulfilled; }
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

  private void Awake()
  {
    m_spriteRen = GetComponent<SpriteRenderer>();
    if (m_starstLit)
    {
      Lit();
    }
    else
    {
      Unlit();
    }
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    
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

    m_conditionFulfilled = m_conditionIsLit;

    OnStateChange?.Invoke(m_conditionFulfilled);
    OnLit?.Invoke();
  }

  public void Unlit()
  {
    m_isLit = false;
    SpriteRen.color = Color.white;
    
    m_conditionFulfilled = !m_conditionIsLit;

    OnStateChange?.Invoke(m_conditionFulfilled);
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
