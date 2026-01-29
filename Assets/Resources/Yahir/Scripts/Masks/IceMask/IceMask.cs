using UnityEngine;

public class IceMask : Mask
{
    [SerializeField]
    GameObject m_icePower;

    IcePower _icePower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _icePower = m_icePower.GetComponent<IcePower>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Activate()
    {
        m_icePower.SetActive(true);
        _icePower.activeFlamethrower(GameManager.Instance.Player.MovingDir);
        transform.parent = null;
        return true;
    }
    public override void Deactivate()
    {
        _icePower.deactivateFlamethrower();
    }
}
