using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TorchDoor : MonoBehaviour
{
  [SerializeField] private List<Torch> m_linkedTorches;
  private float m_fulfilledCount = 0;

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
      //torch.OnLit += OnTorchLit;
      //torch.OnUnlit += OnTorchUnlit;

      //if (!m_openWhenLit)
      //{
      //  torch.IsForeverLit = true;
      //  if (!torch.IsLit)
      //  {
      //    torch.Lit();
      //  }
      //}
      //else
      //{
      //  if (torch.IsLit)
      //  {
      //    torch.Unlit();
      //  }
      //}

      if (torch.ConditionFulfilled)
      {
        ++m_fulfilledCount;
        if (m_fulfilledCount == m_linkedTorches.Count)
        {
          OpenDoor();
        }
      }
      torch.OnStateChange += OnTorchChanged;
    }
  }

  private void OnTorchChanged(bool isFulfilled)
  {
    if (m_isOpen)
    {
      return;
    }

    if (isFulfilled)
    {
      ++m_fulfilledCount;
      if (m_fulfilledCount == m_linkedTorches.Count)
      {
        OpenDoor();
      }
    }
    else
    {
      --m_fulfilledCount;
    }
  }

  //private void OnTorchLit()
  //{
  //  ++m_fulfilledCount;
  //  if (m_fulfilledCount == m_linkedTorches.Count && m_openWhenLit)
  //  {
  //    OpenDoor();
  //  }
  //}

  //private void OnTorchUnlit()
  //{
  //  --m_fulfilledCount;
  //  if (m_openWhenLit)
  //  {
  //    if (m_isOpen)
  //    {
  //      return;
  //    }

  //    if (m_fulfilledCount < m_linkedTorches.Count)
  //    {
  //      CloseDoor();
  //    }
  //  }
  //  else
  //  {
  //    if (m_fulfilledCount == 0)
  //    {
  //      OpenDoor();
  //    }
  //  }
  //}

  // Update is called once per frame
  void Update()
  {

  }

  private void OpenDoor()
  {
    m_isOpen = true;

    foreach (Torch torch in m_linkedTorches)
    {
      if (torch.ConditionIsLit)
      {
        torch.IsForeverLit = true;
        torch.Lit();
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
