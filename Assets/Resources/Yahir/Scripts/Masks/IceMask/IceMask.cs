using UnityEngine;

public class IceMask : Mask
{
  [SerializeField]
  GameObject m_icePower;

  GameObject _icePowerGO;

  IcePower _icePower;


  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Awake()
  {

  }

  protected override void Start()
  {
    m_type = MaskTypes.ICE;
    base.Start();

  }

  // Update is called once per frame
  protected override void Update()
  {
    base.Update();
  }

  public override bool Activate()
  {
    if (!base.Activate())
    {
      return false;
    }

    _icePowerGO = Instantiate(m_icePower);
    _icePower = _icePowerGO.GetComponent<IcePower>();
    _icePowerGO.SetActive(true);
    _icePower.activeFlamethrower(GameManager.Instance.Player.LastMovingDir);
    _icePower.setGameObject(gameObject);

    m_active = true;
    return true;
  }
  public override void Deactivate()
  {
    m_active = false;
    _icePower.deactivateFlamethrower();
  }
}
