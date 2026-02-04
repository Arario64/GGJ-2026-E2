using UnityEngine;

public class PlayingState : IState
{

  public void EnterState()
  {
    Time.timeScale = 1.0f;
    GameManager.Instance.UI.ShowPanel(GameManager.Instance.UI.HUDPanel, true);
    GameManager.Instance.InputActions.Paused.Disable();
    GameManager.Instance.InputActions.Playing.Enable();
    GameManager.Instance.Player.gameObject.SetActive(true);

    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    AudioManager.Instance.PlayMusic(MusicTag.Mazmorra_01);
  }

  public void Execute()
  {

  }

  public IState CheckExitConditions()
  {
    IState nextState = this;

    if (GameManager.Instance.Paused)
    {
      nextState = GameManager.Instance.PauseState;
    }
    if (GameManager.Instance.IsGameOver)
    {
      nextState = GameManager.Instance.GameOverState;
    }

    return nextState;
  }

  public void ExitState()
  {
    GameManager.Instance.Playing = false;

    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }
}
