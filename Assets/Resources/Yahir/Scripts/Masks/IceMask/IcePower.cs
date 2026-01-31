using UnityEngine;
using UnityEngine.UI;

public class IcePower : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_fireCollider;

    GameObject _iceMaskGameObject;

    public float m_currentLength = 0f;
    public float m_maxLength = 4f;
    public float m_growSpeed = 1.0f;

    public float m_shrinkSpeed = 12f;

    private float _growthTime = 0.0f;

    public float m_timeAtack = 0.5f;

    private bool _active = false;

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
            _growthTime += Time.deltaTime;
            if (_growthTime > m_timeAtack && m_currentLength < m_maxLength)
            {
                m_currentLength += 1.0f;
                m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);
                m_fireCollider.offset = new Vector2(m_currentLength / 2f, 0f);
                float visualScale = m_currentLength;
                _spriteRender.transform.localScale = new Vector3(visualScale, 1f, 1f);
                _growthTime = 0.0f;
            }
            else if (_growthTime > 0.5f && m_currentLength >= m_maxLength)
            {
                _active = false;
            }
        }
        else
        {
            _growthTime += Time.deltaTime;
            if (_growthTime > m_timeAtack && m_currentLength > 0.0f)
            {
                m_currentLength -= 1.0f;
                m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);

                m_fireCollider.offset = new Vector2(m_maxLength - (m_currentLength / 2f),
                                                    0f);
                float visualScale = m_currentLength;
                _spriteRender.transform.localScale = new Vector3(visualScale, 1f, 1f);
                if (m_currentLength <= 0.01f)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }
                _growthTime = 0.0f;
            }
        }
    }

    public void activeFlamethrower(Vector2 direction)
    {
        if (_active || m_currentLength > 0.0f)
        {
            return;
        }
        transform.right = direction;
        m_currentLength = 0f;
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
        //_active = false;
    }

    public void setGameObject(GameObject GO)
    {
        _iceMaskGameObject = GO;
        transform.position = GO.transform.position;
    }
}
