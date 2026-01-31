using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TorchDoor : MonoBehaviour
{
  [SerializeField] private List<Torch> m_linkedTorches;

  [Tooltip("If true, the door opens when all torches are lit. If false, the door opens when all torches are unlit.")]
  [SerializeField] private bool m_openWhenLit = true;
  private float m_litCount = 0;

  private BoxCollider2D m_doorCollider;
  private SpriteRenderer m_spriteRen;

  private bool m_isOpen = false;

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

      if (!m_openWhenLit)
      {
        torch.IsForeverLit = true;
        if (!torch.IsLit)
        {
          torch.Lit();
        }
      }
      else
      {
        if (torch.IsLit)
        {
          torch.Unlit();
        }
      }

    }
  }

  private void OnTorchLit()
  {
    ++m_litCount;
    if (m_litCount == m_linkedTorches.Count && m_openWhenLit)
    {
      OpenDoor();
    }
  }

  private void OnTorchUnlit()
  {
    --m_litCount;
    if (m_openWhenLit)
    {
      if (m_isOpen)
      {
        return;
      }

      if (m_litCount < m_linkedTorches.Count)
      {
        CloseDoor();
      }
    }
    else
    {
      if (m_litCount == 0)
      {
        OpenDoor();
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OpenDoor()
  {
    m_isOpen = true;
    if (m_openWhenLit)
    {
      foreach (Torch torch in m_linkedTorches)
      {
        torch.IsForeverLit = true;
      }
    }

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
