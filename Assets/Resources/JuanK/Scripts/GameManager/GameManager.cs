using NUnit.Framework;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public static class CustomAssert
{
  public static void IsNotNull(object obj, string message = "Assertion failed: Object is null")
  {
    if (obj == null)
    {
      Debug.LogError(message);
    }
  }
}


public class GameManager : MonoBehaviour
{
  #region Members

  private FSM m_FSM;
  private MainMenuState m_mainMenuState;
  private PlayingState m_playingState;
  private PauseState m_pauseState;
  private GameOverState m_gameOverState;

  private IA_Player m_playerInputActions;
  private Player m_player;
  private UIManager m_uiManager;
  private WinZone m_winZone;

  private bool m_paused = false;
  private bool m_playing = false;
  private bool m_gameOver = false;
  private bool m_gameWon = false;
  private bool m_inMainMenu = false;

  #endregion Members

  #region Getters / Setters

  public FSM StateMachine
  { 
    get
    {
      m_FSM ??= new FSM();
      return m_FSM;
    }
  }

  public IState MainMenuState
  {
    get
    {
      m_mainMenuState ??= new MainMenuState();
      return m_mainMenuState;
    }
  }

  public IState PlayingState
  {
    get
    {
      m_playingState ??= new PlayingState();
      return m_playingState;
    }
  }

  public IState PauseState
  {
    get
    {
      m_pauseState ??= new PauseState();
      return m_pauseState;
    }
  }

  public IState GameOverState
  {
    get
    {
      m_gameOverState ??= new GameOverState();
      return m_gameOverState;
    }
  }

  public IA_Player InputActions
  {
    get
    {
      m_playerInputActions ??= new IA_Player();
      return m_playerInputActions;
    }
  }

  public UIManager UI
  {
    get
    {
      if (m_uiManager == null)
      {
        m_uiManager = FindFirstObjectByType<UIManager>();
      }
      return m_uiManager;
    }
  }

  public Player Player
  {
    get
    {
      if (m_player == null)
      {
        m_player = FindAnyObjectByType<Player>();
      }
      return m_player;
    }
  }

  public WinZone WinZone
  {
    get
    {
      if (m_winZone == null)
      {
        int winZones = FindObjectsByType<WinZone>(FindObjectsSortMode.None).Length;
        if (winZones > 1)
        {
          throw new System.Exception("There should be only one WinZone in the scene, but found: " + winZones);
        }
        m_winZone = FindFirstObjectByType<WinZone>();
      }
      return m_winZone;
    }
  }

  public bool Paused
  {
    get { return m_paused; }
    set { m_paused = value; }
  }
  public bool Playing
  {
    get { return m_playing; }
    set { m_playing = value; }
  }
  public bool InMainMenu
  {
    get { return m_inMainMenu; }
    set { m_inMainMenu = value; }
  }
  public bool IsGameOver
  {
    get { return m_gameOver; }
    set { m_gameOver = value; }
  }
  public bool IsGameWon
  {
    get { return m_gameWon; }
    set { m_gameWon = value; }
  }


  public static GameManager Instance { get { return m_instance; } }
  public static GameManager m_instance { get; private set; }

  #endregion Getters / Setters

  private void Awake()
  {
    if (m_instance == null)
    {
      m_instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  private void OnDestroy()
  {
    if (Instance == this)
    {
      SceneManager.sceneLoaded -= OnSceneLoaded;
    }
  }

  private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    CustomAssert.IsNotNull(StateMachine);
    CustomAssert.IsNotNull(InputActions);
    CustomAssert.IsNotNull(Player);
    CustomAssert.IsNotNull(UI);
    //CustomAssert.IsNotNull(WinZone);
    CustomAssert.IsNotNull(MainMenuState);
    CustomAssert.IsNotNull(PlayingState);
    CustomAssert.IsNotNull(PauseState);
    CustomAssert.IsNotNull(GameOverState);

    InputActions.Paused.Disable();
    InputActions.Playing.Enable();

    InputActions.Playing.Pause.performed += OnPauseGame;
    InputActions.Playing.Restart.performed += OnResetGame;
    InputActions.Paused.Restart.performed += OnResetGame;
    InputActions.Paused.Resume.performed += OnResumeGame;

    Player.gameObject.SetActive(false);
    StateMachine.Init(MainMenuState);
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    StateMachine.Update();
  }

  private void OnPauseGame(InputAction.CallbackContext context)
  {
    Paused = true;
  }

  private void OnResumeGame(InputAction.CallbackContext context)
  {
    Playing = true;
  }

  private void OnResetGame(InputAction.CallbackContext context)
  {
    Playing = true;
    ResetGame();
  }

  public void ResetGame()
  {
    Playing = true;

    //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);

    //Player.Reset();
  }

  public void QuitGame()
  {
  #if UNITY_EDITOR
    EditorApplication.isPlaying = false;
  #else
    Application.Quit();
  #endif
  }
}
