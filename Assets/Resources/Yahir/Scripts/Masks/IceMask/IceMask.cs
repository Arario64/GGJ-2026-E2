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
    _icePowerGO = Instantiate(m_icePower);
    _icePower = _icePowerGO.GetComponent<IcePower>();
    _icePowerGO.SetActive(true);
    _icePower.activeFlamethrower(GameManager.Instance.Player.LastMovingDir);
    _icePower.setGameObject(gameObject);
    return true;
  }
  public override void Deactivate()
  {
    _icePower.deactivateFlamethrower();
  }
}
