using System.Drawing;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
  [SerializeField] private BoxCollider2D m_fireCollider;

  private GameObject _fireMaskGameObject;

  public float m_currentLength = 0f;
  public float m_maxLength = 4f;
  public float m_growSpeed = 1.0f;

  public float m_shrinkSpeed = 12f;

  private bool _active = true;

  [SerializeField]
  private GameObject _spriteRender;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    //_rectangle = GetComponent<Rectangle>();
  }

  // Update is called once per frame
  void Update()
  {
    if (_active)
    {
      transform.position = _fireMaskGameObject.transform.position;
      m_currentLength = Mathf.MoveTowards(m_currentLength,
                                          m_maxLength,
                                          m_growSpeed * Time.deltaTime);

      m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);
      m_fireCollider.offset = new Vector2(m_currentLength / 2f, 0f);
      float visualScale = m_currentLength; 
      _spriteRender.transform.localScale = new Vector3(visualScale, 1f, 1f);
      //_spriteRender.transform.position = new Vector3(transform.position.x + m_currentLength / 2f, _spriteRender.transform.position.y, _spriteRender.transform.position.z);
            //SpriteRenderer sr = _spriteRender.GetComponent<SpriteRenderer>();
            //sr.transform.
    }
    else
    {
      transform.position = _fireMaskGameObject.transform.position;
      m_currentLength = Mathf.MoveTowards(m_currentLength,
                                          0f,
                                          m_shrinkSpeed * Time.deltaTime);

      m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);

      m_fireCollider.offset = new Vector2(m_maxLength - (m_currentLength / 2f),
                                          0f);

      float visualScale = m_currentLength;
      _spriteRender.transform.localScale = new Vector3(visualScale, 1f, 1f);
      //_spriteRender.transform.localScale = new Vector3(m_fireCollider.size.x, 1.0f, 1.0f);
      //_spriteRender.transform.position = new Vector3(transform.position.x + m_fireCollider.offset.x, transform.position.y, transform.position.z);
      if (m_currentLength <= 0.01f)
      {
        gameObject.SetActive(false);
        Destroy(gameObject);
      }
    }

    }

  public void activeFlamethrower(Vector2 direction)
  {
    transform.right = direction;
    m_currentLength = 0f;
    //_spriteRender.transform.right = direction;
    _active = true;
  }

    private void OnDrawGizmos()
    {
        if (!m_fireCollider) return;

        Gizmos.color = UnityEngine.Color.black;
        Gizmos.DrawWireCube(m_fireCollider.bounds.center, m_fireCollider.bounds.size);
    }

    public void deactivateFlamethrower()
  {
    _active = false;
  }

  public void setGameObject(GameObject GO)
  {
    _fireMaskGameObject = GO;
  }
}
