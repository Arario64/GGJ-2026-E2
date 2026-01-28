using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  private GameObject m_canvas;
  private GameObject m_mainMenuPanel;
  private GameObject m_instructionsPanel;
  private GameObject m_audioPanel;
  private GameObject m_hudPanel;
  private GameObject m_pausePanel;
  private GameObject m_gameOverPanel;
  private GameObject m_winPanel;

  private TextMeshProUGUI m_gameOverText;
  private TextMeshProUGUI m_ammoText;
  private Slider m_fuelSlider;

  public GameObject Canvas
  {
    get
    {
      if (m_canvas == null)
      {
        m_canvas = transform.Find("Canvas").gameObject;
      }
      return m_canvas;
    }
  }

  public GameObject MainMenuPanel
  {
    get
    {
      if (m_mainMenuPanel == null)
      {
        m_mainMenuPanel = Canvas.transform.Find("MainMenuPanel").gameObject;
      }
      return m_mainMenuPanel;
    }
  }

  public GameObject InstructionsPanel
  {
    get
    {
      if (m_instructionsPanel == null)
      {
        m_instructionsPanel = Canvas.transform.Find("HowToPlayPanel").gameObject;
      }
      return m_instructionsPanel;
    }
  }

  public GameObject AudioPanel
  {
    get
    {
      if (m_audioPanel == null)
      {
        m_audioPanel = Canvas.transform.Find("AudioPanel").gameObject;
      }
      return m_audioPanel;
    }
  }

  public GameObject HUDPanel
  {
    get
    {
      if (m_hudPanel == null)
      {
        m_hudPanel = Canvas.transform.Find("HUD").gameObject;
      }
      return m_hudPanel;
    }
  }

  public GameObject PausePanel
  {
    get
    {
      if (m_pausePanel == null)
      {
        m_pausePanel = Canvas.transform.Find("PausePanel").gameObject;
      }
      return m_pausePanel;
    }
  }

  public GameObject GameOverPanel
  {
    get
    {
      if (m_gameOverPanel == null)
      {
        m_gameOverPanel = Canvas.transform.Find("GameOverPanel").gameObject;
      }
      return m_gameOverPanel;
    }
  }

  public TextMeshProUGUI GameOverText
  {
    get
    {
      if (m_gameOverText == null)
      {
        m_gameOverText = GameOverPanel.transform.Find("GameOverText").gameObject.GetComponent<TextMeshProUGUI>();
      }
      return m_gameOverText;
    }
    set { m_gameOverText = value; }
  }

  public GameObject WinPanel
  {
    get
    {
      if (m_winPanel == null)
      {
        m_winPanel = Canvas.transform.Find("WinPanel").gameObject;
      }
      return m_winPanel;
    }
  }

  public Slider FuelSlider
  {
    get
    {
      if (m_fuelSlider == null)
      {
        m_fuelSlider = HUDPanel.transform.Find("Fuel").gameObject.GetComponent<Slider>();
      }
      return m_fuelSlider;
    }
    set { m_fuelSlider = value; }
  }

  public TextMeshProUGUI AmmoText
  {
    get
    {
      if (m_ammoText == null)
      {
        m_ammoText = HUDPanel.transform.Find("AmmoText").gameObject.GetComponent<TextMeshProUGUI>();
      }
      return m_ammoText;
    }
    set { m_ammoText = value; }
  }

  private void Start()
  {
    //TODO: Uncomment after UI is complete

    //CustomAssert.IsNotNull(Canvas);
    //CustomAssert.IsNotNull(MainMenuPanel);
    //CustomAssert.IsNotNull(InstructionsPanel);
    //CustomAssert.IsNotNull(AudioPanel);
    //CustomAssert.IsNotNull(HUDPanel);
    //CustomAssert.IsNotNull(PausePanel);
    //CustomAssert.IsNotNull(GameOverPanel);
    //CustomAssert.IsNotNull(GameOverText);
    //CustomAssert.IsNotNull(WinPanel);
  }

  public void ShowPanel(GameObject panel, bool showHUD = false)
  {
    //TODO: Uncomment after UI is complete

    //MainMenuPanel.SetActive(MainMenuPanel == panel);
    //InstructionsPanel.SetActive(InstructionsPanel == panel);
    //AudioPanel.SetActive(AudioPanel == panel);
    //HUDPanel.SetActive(HUDPanel == panel || showHUD);
    //PausePanel.SetActive(PausePanel == panel);
    //GameOverPanel.SetActive(GameOverPanel == panel);
    //WinPanel.SetActive(WinPanel == panel);
  }

  public void InfoUpdate()
  {

  }

  public void OnMainMenuClicked()
  {
    GameManager.Instance.ResetGame();
    GameManager.Instance.InMainMenu = true;
    GameManager.Instance.Playing = false;
  }

  public void OnPlayFromMenuClicked()
  {
    GameManager.Instance.Playing = true;
    //GameManager.Instance.ResetGame();
  }

  public void OnHowToPlayClicked()
  {
    ShowPanel(InstructionsPanel);
  }

  public void OnBackClicked()
  {
    if (GameManager.Instance.InMainMenu)
    {
      ShowPanel(MainMenuPanel);
    }
    else if (GameManager.Instance.Paused)
    {
      ShowPanel(PausePanel);
    }    
  }

  public void OnAudioClicked()
  {
    ShowPanel(AudioPanel);
  }

  public void OnMusicVolumeChanged(float volume)
  {
    
  }

  public void OnSFXVolumeChanged(float volume)
  {
    
  }

  public void OnRetryClicked(bool reset = false)
  {
    GameManager.Instance.Playing = true;
    if (reset)
    {
      GameManager.Instance.ResetGame();
    }
  }
  public void OnRestartClicked()
  {
    GameManager.Instance.Playing = true;
    
    GameManager.Instance.ResetGame();
  }

  public void OnExitClicked()
  {
    GameManager.Instance.QuitGame();
  }
}
