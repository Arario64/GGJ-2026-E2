using Unity.VisualScripting;
using UnityEngine;

public class MainMenuState : IState
{

  public void EnterState()
  {
    GameManager.Instance.UI.ShowPanel(GameManager.Instance.UI.MainMenuPanel);
    GameManager.Instance.InputActions.Paused.Disable();
    GameManager.Instance.InputActions.Playing.Disable();
    Time.timeScale = 0.0f;

    GameManager.Instance.InMainMenu = true;
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
    return nextState;
  }

  public void ExitState()
  {
    GameManager.Instance.InMainMenu = false;
  }
}
