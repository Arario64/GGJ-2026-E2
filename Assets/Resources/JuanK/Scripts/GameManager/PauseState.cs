using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseState : IState
{

  public void EnterState()
  {
    GameManager.Instance.UI.ShowPanel(GameManager.Instance.UI.PausePanel, true);
    GameManager.Instance.InputActions.Paused.Enable();
    GameManager.Instance.InputActions.Playing.Disable();

    Time.timeScale = 0.0f;

    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }

  public void Execute()
  {

  }

  public IState CheckExitConditions()
  {
    IState nextState = this;

    if (GameManager.Instance.Playing)
    {
      nextState = GameManager.Instance.PlayingState;
    }
    if (GameManager.Instance.InMainMenu)
    {
      nextState = GameManager.Instance.MainMenuState;
    }
    return nextState;
  }

  public void ExitState()
  {
    GameManager.Instance.Paused = false;
  }
}
