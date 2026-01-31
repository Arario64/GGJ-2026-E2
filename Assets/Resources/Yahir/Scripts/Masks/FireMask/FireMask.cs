using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMask : Mask
{
    [SerializeField]
    GameObject m_flamethrower;

    GameObject _flamethrowerGO;

    Flamethrower _flamethrower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

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
        //m_flamethrower.SetActive(true);

        _flamethrowerGO = Instantiate(m_flamethrower);
        _flamethrower = _flamethrowerGO.GetComponent<Flamethrower>();
        _flamethrowerGO.SetActive(true);
        _flamethrower.activeFlamethrower(GameManager.Instance.Player.MovingDir);
        _flamethrower.setGameObject(gameObject);
        return true;
    }
    public override void Deactivate()
    {
        _flamethrower.deactivateFlamethrower();
    }
}
