using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMask : Mask
{
  [SerializeField]
  GameObject m_flamethrower;

  GameObject _flamethrowerGO;

  Flamethrower _flamethrower;

  private bool _isFiring = false;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Awake()
  {

  }

  protected override void Start()
  {
    m_type = MaskTypes.FIRE;
    base.Start();
  }

  // Update is called once per frame
  protected override void Update()
  {
    base.Update();
    if (m_active)
    {
      if (!Activate())
      {
        Deactivate();
      }
    }
  }

  public override bool Activate()
  {
    if (!base.Activate())
    {
      return false;
    }

    if (_isFiring)
    {
      return true;
    }

    _flamethrowerGO = Instantiate(m_flamethrower);
    _flamethrower = _flamethrowerGO.GetComponent<Flamethrower>();
    _flamethrowerGO.SetActive(true);
    _flamethrower.activeFlamethrower(GameManager.Instance.Player.LastMovingDir);
    _flamethrower.setGameObject(gameObject);

    m_active = true;
    _isFiring = true;
    return true;
  }
  public override void Deactivate()
  {
    _flamethrower.deactivateFlamethrower();
    m_active = false;
    _isFiring = false;
  }
}
