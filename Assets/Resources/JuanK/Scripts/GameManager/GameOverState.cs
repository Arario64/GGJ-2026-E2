using UnityEngine;

public class GameOverState : IState
{

  public void EnterState()
  {
    if (GameManager.Instance.IsGameWon)
    {
      GameManager.Instance.UI.ShowPanel(GameManager.Instance.UI.WinPanel);
    }
    else
    {
      GameManager.Instance.UI.ShowPanel(GameManager.Instance.UI.GameOverPanel);
    }

    GameManager.Instance.InputActions.Playing.Disable();
    Time.timeScale = 0.0f;

    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    AudioManager.Instance.PlayMusic(MusicTag.Menu);
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
    else if (GameManager.Instance.InMainMenu)
    {
      nextState = GameManager.Instance.MainMenuState;
    }
    return nextState;
  }

  public void ExitState()
  {
    GameManager.Instance.IsGameOver = false;
    GameManager.Instance.IsGameWon = false;
  }
}
