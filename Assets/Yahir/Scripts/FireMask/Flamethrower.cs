using System.Drawing;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_fireCollider;

    public float m_currentLength = 0f;
    public float m_maxLength = 4f;
    public float m_growSpeed = 1.0f;

    public float m_shrinkSpeed = 12f;

    private bool _active = true;

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
            m_currentLength = Mathf.MoveTowards(m_currentLength,
                                                m_maxLength,
                                                m_growSpeed * Time.deltaTime);

            m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);
            m_fireCollider.offset = new Vector2(m_currentLength / 2f, 0f);
        }
        else
        {
            m_currentLength = Mathf.MoveTowards(m_currentLength,
                                                0f,
                                                m_shrinkSpeed * Time.deltaTime);

            m_fireCollider.size = new Vector2(m_currentLength, m_fireCollider.size.y);

            m_fireCollider.offset = new Vector2(m_maxLength - (m_currentLength / 2f),
                                                0f);

            if (m_currentLength <= 0.01f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void activeFlamethrower(Vector2 direction)
    {
        transform.right = direction;
        m_currentLength = 0f;
        _active = true;
    }

    public void turnOffFlamethrower()
    {
        _active = false;
    }
}
