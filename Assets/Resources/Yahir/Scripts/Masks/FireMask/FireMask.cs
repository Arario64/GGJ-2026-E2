using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMask : Mask
{
  [SerializeField]
  GameObject m_flamethrower;

  Flamethrower _flamethrower;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Awake()
  {
    _flamethrower = m_flamethrower.GetComponent<Flamethrower>();
  }

  protected override void Start()
  {
    base.Start();

  }

  // Update is called once per frame
  void Update()
  {
    //var keyboard = Keyboard.current;
    //if (keyboard == null) return;

    //if (keyboard.wKey.wasPressedThisFrame)
    //{
    //    Activate();
    //}
    //else if (keyboard.aKey.wasPressedThisFrame)
    //{
    //    Activate();
    //}
    //else if (keyboard.sKey.wasPressedThisFrame)
    //{
    //    Activate();
    //}
    //else if (keyboard.dKey.wasPressedThisFrame)
    //{
    //    Activate();
    //}
    //else if (keyboard.lKey.wasPressedThisFrame)
    //{
    //    Deactivate();
    //}
  }

  public override bool Activate()
  {
    m_flamethrower.SetActive(true);
    _flamethrower.activeFlamethrower(GameManager.Instance.Player.MovingDir);
    return true;
  }
  public override void Deactivate()
  {
    _flamethrower.deactivateFlamethrower();
  }
}
