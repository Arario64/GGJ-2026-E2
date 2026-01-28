using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireMask : MonoBehaviour
{
    [SerializeField]
    float m_timeLife = 100.0f;

    [SerializeField]
    GameObject m_flamethrower;

    Flamethrower _flamethrower;
    public event Action OnFireActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _flamethrower = m_flamethrower.GetComponent<Flamethrower>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.wKey.wasPressedThisFrame)
        {
            activateFlamethrower(new Vector2(0.0f, 1.0f));
        }
        else if (keyboard.aKey.wasPressedThisFrame)
        {
            activateFlamethrower(new Vector2(-1.0f, 0.0f));
        }
        else if (keyboard.sKey.wasPressedThisFrame)
        {
            activateFlamethrower(new Vector2(0.0f, -1.0f));
        }
        else if (keyboard.dKey.wasPressedThisFrame)
        {
            activateFlamethrower(new Vector2(1.0f, 0.0f));
        }
        else if (keyboard.lKey.wasPressedThisFrame)
        {
            turnOffFlamethrower();
        }
    }

    public void activateFlamethrower(Vector2 direction)
    {
        m_flamethrower.SetActive(true);
        _flamethrower.activeFlamethrower(direction);
    }
    public void turnOffFlamethrower()
    {
        _flamethrower.turnOffFlamethrower();
    }
}
