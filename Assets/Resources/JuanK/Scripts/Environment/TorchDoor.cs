using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TorchDoor : MonoBehaviour
{
  [SerializeField] private List<Torch> m_linkedTorches;
  [SerializeField] private List<Torch> m_linkedTorches2;
  private float m_litCount = 0;

  private BoxCollider2D m_doorCollider;
  private SpriteRenderer m_spriteRen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    m_doorCollider = GetComponent<BoxCollider2D>();
    m_spriteRen = GetComponent<SpriteRenderer>();
    CloseDoor();
    foreach (var torch in m_linkedTorches)
    {
      torch.OnLit += OnTorchLit;
      torch.OnUnlit += OnTorchUnlit;
    }
  }

  private void OnTorchLit()
  {
    ++m_litCount;
    if (m_litCount == m_linkedTorches.Count)
    {
      OpenDoor();
    }
  }

  private void OnTorchUnlit()
  {
    --m_litCount;
    if (m_litCount < m_linkedTorches.Count)
    {
      CloseDoor();
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OpenDoor()
  {
    m_doorCollider.enabled = false;

    Color color = m_spriteRen.color;
    color.a = 0.2f;
    m_spriteRen.color = color;
  }

  private void CloseDoor()
  {
    m_doorCollider.enabled = true;

    Color color = m_spriteRen.color;
    color.a = 1.0f;
    m_spriteRen.color = color;
  }

}
