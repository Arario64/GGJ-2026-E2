using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : Singletone<Inputs>
{
    public static PlayerInput _playerInput;

    public static InputAction moveP1;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != this)
        {
            return;
        }
        _playerInput = GetComponent<PlayerInput>();

    }

    ///---PAUSA
    public static bool Pause()
    {
        return _playerInput.actions["Pause"].WasPressedThisFrame();
    }

    //--- ACTIONS ---
    public static bool ButtonA()
    {
        return _playerInput.actions["Button_A"].WasPressedThisFrame();
    }
    public static bool ButtonS()
    {
        return _playerInput.actions["Button_S"].WasPressedThisFrame();
    }
    public static bool ButtonD()
    {
        return _playerInput.actions["Button_D"].WasPressedThisFrame();
    }
    public static bool ButtonW()
    {
        return _playerInput.actions["Button_W"].WasPressedThisFrame();
    }
    public static bool ButtonShift()
    {
        return _playerInput.actions["Button_Shift"].WasPressedThisFrame();
    }
    public static bool ButtonE()
    {
        return _playerInput.actions["Button_E"].WasPressedThisFrame();
    }
    public static bool Jump()
    {
        return _playerInput.actions["Jump"].WasPressedThisFrame();
    }

    ///---AUDIO---
    public static bool increase()
    {
        return _playerInput.actions["increase"].WasPressedThisFrame();
    }

    public static bool decrease()
    {
        return _playerInput.actions["decrease"].WasPressedThisFrame();
    }

    public static bool increaseMain()
    {
        return _playerInput.actions["increaseMain"].WasPressedThisFrame();
    }

    public static bool decreaseMain()
    {
        return _playerInput.actions["decreaseMain"].WasPressedThisFrame();
    }
    public static bool increaseSFX()
    {
        return _playerInput.actions["increaseSFX"].WasPressedThisFrame();
    }

    public static bool decreaseSFX()
    {
        return _playerInput.actions["decreaseSFX"].WasPressedThisFrame();
    }

    //---MUSIC--
    public static bool Running()
    {
        return _playerInput.actions["Running"].WasPressedThisFrame();
    }
    public static bool MenuMusic()
    {
        return _playerInput.actions["MenuMusic"].WasPressedThisFrame();
    }

    ////---SFX--
    //public static bool Key()
    //{
    //    return _playerInput.actions["Key"].WasPressedThisFrame();
    //}
    //public static bool Hurt()
    //{
    //    return _playerInput.actions["Hurt"].WasPressedThisFrame();
    //}
}
