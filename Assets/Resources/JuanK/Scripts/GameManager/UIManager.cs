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
  private Slider m_currMaskSlider;
  private Slider m_fireMaskSlider;
  private Slider m_iceMaskSlider;
  private Slider m_invisibilityMaskSlider;
  private Slider m_truthMaskSlider;
  private Slider m_teleportMaskSlider;

  private Image m_currMaskFill;
  private Image m_fireMaskFill;
  private Image m_iceMaskFill;
  private Image m_invisibilityMaskFill;
  private Image m_truthMaskFill;
  private Image m_teleportMaskFill;

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

  public Slider CurrMaskSlider
  {
    get
    {
      if (m_currMaskSlider == null)
      {
        m_currMaskSlider = HUDPanel.transform.Find("CurrMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_currMaskSlider;
    }
    set { m_currMaskSlider = value; }
  }

  public Slider FireMaskSlider
  {
    get
    {
      if (m_fireMaskSlider == null)
      {
        m_fireMaskSlider = HUDPanel.transform.Find("FireMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_fireMaskSlider;
    }
    set { m_fireMaskSlider = value; }
  }

  public Slider IceMaskSlider
  {
    get
    {
      if (m_iceMaskSlider == null)
      {
        m_iceMaskSlider = HUDPanel.transform.Find("IceMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_iceMaskSlider;
    }
    set { m_iceMaskSlider = value; }
  }

  public Slider InvisibilityMaskSlider
  {
    get
    {
      if (m_invisibilityMaskSlider == null)
      {
        m_invisibilityMaskSlider = HUDPanel.transform.Find("InvisibilityMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_invisibilityMaskSlider;
    }
    set { m_invisibilityMaskSlider = value; }
  }

  public Slider TruthMaskSlider
  {
    get
    {
      if (m_truthMaskSlider == null)
      {
        m_truthMaskSlider = HUDPanel.transform.Find("TruthMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_truthMaskSlider;
    }
    set { m_truthMaskSlider = value; }
  }

  public Slider TeleportMaskSlider
  {
    get
    {
      if (m_teleportMaskSlider == null)
      {
        m_teleportMaskSlider = HUDPanel.transform.Find("TeleportMaskPower").gameObject.GetComponent<Slider>();
      }
      return m_teleportMaskSlider;
    }
    set { m_teleportMaskSlider = value; }
  }

  public Image CurrMaskFill
  {
    get
    {
      if (m_currMaskFill == null)
      {
        m_currMaskFill = CurrMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_currMaskFill;
    }
    set { m_currMaskFill = value; }
  }

  public Image FireMaskFill
  {
    get
    {
      if (m_fireMaskFill == null)
      {
        m_fireMaskFill = FireMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_fireMaskFill;
    }
    set { m_fireMaskFill = value; }
  }

  public Image IceMaskFill
  {
    get
    {
      if (m_iceMaskFill == null)
      {
        m_iceMaskFill = IceMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_iceMaskFill;
    }
    set { m_iceMaskFill = value; }
  }

  public Image InvisibilityMaskFill
  {
    get
    {
      if (m_invisibilityMaskFill == null)
      {
        m_invisibilityMaskFill = InvisibilityMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_invisibilityMaskFill;
    }
    set { m_invisibilityMaskFill = value; }
  }

  public Image TruthMaskFill
  {
    get
    {
      if (m_truthMaskFill == null)
      {
        m_truthMaskFill = TruthMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_truthMaskFill;
    }
    set { m_truthMaskFill = value; }
  }

  public Image TeleportMaskFill
  {
    get
    {
      if (m_teleportMaskFill == null)
      {
        m_teleportMaskFill = TeleportMaskSlider.fillRect.GetComponentInChildren<Image>();
      }
      return m_teleportMaskFill;
    }
    set { m_teleportMaskFill = value; }
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
    Mask fireMask = FindAnyObjectByType<FireMask>();
    //Mask iceMask = FindAnyObjectByType<IceMask>();
    Mask invisibilityMask = FindAnyObjectByType<InvisibilityMask>();
    Mask truthMask = FindAnyObjectByType<TruthSeerMask>();
    Mask teleportMask = FindAnyObjectByType<TeleportMask>();

    fireMask.OnPowerChange += UpdateMaskPower;
    //iceMask.OnPowerChange += UpdateMaskPower;
    invisibilityMask.OnPowerChange += UpdateMaskPower;
    truthMask.OnPowerChange += UpdateMaskPower;
    teleportMask.OnPowerChange += UpdateMaskPower;

    CurrMaskFill.color = Color.clear; //Initial color
    FireMaskFill.color = /*fireMask.MaskColor*/ Color.red;
    IceMaskFill.color = /*iceMask.MaskColor*/new (0.0f, 0.8287549f, 1.0f, 1.0f);
    InvisibilityMaskFill.color = invisibilityMask.MaskColor;
    TruthMaskFill.color = truthMask.MaskColor;
    TeleportMaskFill.color = teleportMask.MaskColor;

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
    HUDPanel.SetActive(HUDPanel == panel || showHUD);
    //PausePanel.SetActive(PausePanel == panel);
    //GameOverPanel.SetActive(GameOverPanel == panel);
    //WinPanel.SetActive(WinPanel == panel);
  }

  public void InfoUpdate()
  {

  }

  public void AddMaskToInventory(Mask mask)
  {
    //TODO: Add mask icon to inventory UI

    UpdateMaskPower(mask);
  }

  public void UpdateMaskPower(Mask mask)
  {
    Mask currMask = GameManager.Instance.Player.CurrMask;

    float normalizedPower = mask.CurrPower / mask.MaxPower;

    switch (mask.Type)
    {
      case MaskTypes.FIRE:
      {
        if (currMask == mask)
        {
            UpdateCurrMaskPower(normalizedPower, mask.MaskColor);
        }
        FireMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.ICE:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor);
        }
        IceMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.INVISIBILITY:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor);
        }
        InvisibilityMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.TRUTH:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor);
        }
        TruthMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.TELEPORT:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor);
        }
        TeleportMaskSlider.value = normalizedPower;
        break;
      }
    }
  }

  public void UpdateCurrMaskPower(float normalizedPower, Color sliderColor)
  {
    CurrMaskSlider.value = normalizedPower;
    CurrMaskSlider.image.color = sliderColor;
    
    CurrMaskFill.color = sliderColor;

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
