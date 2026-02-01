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

  private TextMeshProUGUI m_keysText;
  private TextMeshProUGUI m_gameOverText;

  private GameObject m_currMaskSliderGO;
  private GameObject m_fireMaskSliderGO;
  private GameObject m_iceMaskSliderGO;
  private GameObject m_invisibilityMaskSliderGO;
  private GameObject m_truthMaskSliderGO;
  private GameObject m_teleportMaskSliderGO;

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

  private Image m_currMaskIcon;
  private Image m_fireMaskIcon;
  private Image m_iceMaskIcon;
  private Image m_invisibilityMaskIcon;
  private Image m_truthMaskIcon;
  private Image m_teleportMaskIcon;

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

  public TextMeshProUGUI KeysText
  {
    get
    {
      if (m_keysText == null)
      {
        m_keysText = HUDPanel.transform.Find("Keys").gameObject.GetComponentInChildren<TextMeshProUGUI>();
      }
      return m_keysText;
    }
    set { m_keysText = value; }
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

  private GameObject CurrMaskSliderGO
  {
    get
    {
      if (m_currMaskSliderGO == null)
      {
        m_currMaskSliderGO = HUDPanel.transform.Find("CurrMaskPower").gameObject;
      }
      return m_currMaskSliderGO;
    }
    set
    {
      m_currMaskSliderGO = value;
    }
  }

  private GameObject FireMaskSliderGO
  {
    get
    {
      if (m_fireMaskSliderGO == null)
      {
        m_fireMaskSliderGO = HUDPanel.transform.Find("FireMaskPower").gameObject;
      }
      return m_fireMaskSliderGO;
    }
    set
    {
      m_fireMaskSliderGO = value;
    }
  }

  private GameObject IceMaskSliderGO
  {
    get
    {
      if (m_iceMaskSliderGO == null)
      {
        m_iceMaskSliderGO = HUDPanel.transform.Find("IceMaskPower").gameObject;
      }
      return m_iceMaskSliderGO;
    }
    set
    {
      m_iceMaskSliderGO = value;
    }
  }

  private GameObject InvisibilityMaskSliderGO
  {
    get
    {
      if (m_invisibilityMaskSliderGO == null)
      {
        m_invisibilityMaskSliderGO = HUDPanel.transform.Find("InvisibilityMaskPower").gameObject;
      }
      return m_invisibilityMaskSliderGO;
    }
    set
    {
      m_invisibilityMaskSliderGO = value;
    }
  }

  private GameObject TruthMaskSliderGO
  {
    get
    {
      if (m_truthMaskSliderGO == null)
      {
        m_truthMaskSliderGO = HUDPanel.transform.Find("TruthMaskPower").gameObject;
      }
      return m_truthMaskSliderGO;
    }
    set
    {
      m_truthMaskSliderGO = value;
    }
  }

  private GameObject TeleportMaskSliderGO
  {
    get
    {
      if (m_teleportMaskSliderGO == null)
      {
        m_teleportMaskSliderGO = HUDPanel.transform.Find("TeleportMaskPower").gameObject;
      }
      return m_teleportMaskSliderGO;
    }
    set
    {
      m_teleportMaskSliderGO = value;
    }
  }

  public Slider CurrMaskSlider
  {
    get
    {
      if (m_currMaskSlider == null)
      {
        m_currMaskSlider = CurrMaskSliderGO.GetComponent<Slider>();
        CurrMaskSliderGO.SetActive(false);
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
        FireMaskSliderGO.SetActive(false);
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
        IceMaskSliderGO.SetActive(false);
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
        InvisibilityMaskSliderGO.SetActive(false);
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
        TruthMaskSliderGO.SetActive(false);
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
        TeleportMaskSliderGO.SetActive(false);
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
        m_currMaskFill = CurrMaskSlider.fillRect.GetComponentInChildren<Image>(true);
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
        m_fireMaskFill = FireMaskSlider.fillRect.GetComponentInChildren<Image>(true);
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
        m_iceMaskFill = IceMaskSlider.fillRect.GetComponentInChildren<Image>(true);
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
        m_invisibilityMaskFill = InvisibilityMaskSlider.fillRect.GetComponentInChildren<Image>(true);
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
        m_truthMaskFill = TruthMaskSlider.fillRect.GetComponentInChildren<Image>(true);
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
        m_teleportMaskFill = TeleportMaskSlider.fillRect.GetComponentInChildren<Image>(true);
      }
      return m_teleportMaskFill;
    }
    set { m_teleportMaskFill = value; }
  }

  public Image CurrMaskIcon
  {
    get
    {
      if (m_currMaskIcon == null)
      {
        m_currMaskIcon = CurrMaskSlider.transform.Find("CurrMaskIcon").gameObject.GetComponent<Image>();
        m_currMaskIcon.color = Color.clear;
      }
      return m_currMaskIcon;
    }
    set { m_currMaskIcon = value; }
  }

  public Image FireMaskIcon
  {
    get
    {
      if (m_fireMaskIcon == null)
      {
        m_fireMaskIcon = FireMaskSlider.transform.Find("FireMaskIcon").gameObject.GetComponent<Image>();
        m_fireMaskIcon.color = Color.clear;
      }
      return m_fireMaskIcon;
    }
    set { m_fireMaskIcon = value; }
  }

  public Image IceMaskIcon
  {
    get
    {
      if (m_iceMaskIcon == null)
      {
        m_iceMaskIcon = IceMaskSlider.transform.Find("IceMaskIcon").gameObject.GetComponent<Image>();
        m_iceMaskIcon.color = Color.clear;
      }
      return m_iceMaskIcon;
    }
    set { m_iceMaskIcon = value; }
  }

  public Image InvisibilityMaskIcon
  {
    get
    {
      if (m_invisibilityMaskIcon == null)
      {
        m_invisibilityMaskIcon = InvisibilityMaskSlider.transform.Find("InvisibilityMaskIcon").gameObject.GetComponent<Image>();
        m_invisibilityMaskIcon.color = Color.clear;
      }
      return m_invisibilityMaskIcon;
    }
    set { m_invisibilityMaskIcon = value; }
  }

  public Image TruthMaskIcon
  {
    get
    {
      if (m_truthMaskIcon == null)
      {
        m_truthMaskIcon = TruthMaskSlider.transform.Find("TruthMaskIcon").gameObject.GetComponent<Image>();
        m_truthMaskIcon.color = Color.clear;
      }
      return m_truthMaskIcon;
    }
    set { m_truthMaskIcon = value; }
  }

  public Image TeleportMaskIcon
  {
    get
    {
      if (m_teleportMaskIcon == null)
      {
        m_teleportMaskIcon = TeleportMaskSlider.transform.Find("TeleportMaskIcon").gameObject.GetComponent<Image>();
        m_teleportMaskIcon.color = Color.clear;
      }
      return m_teleportMaskIcon;
    }
    set { m_teleportMaskIcon = value; }
  }

  private void Start()
  {
    CustomAssert.IsNotNull(Canvas);
    CustomAssert.IsNotNull(MainMenuPanel);
    CustomAssert.IsNotNull(InstructionsPanel);
    CustomAssert.IsNotNull(AudioPanel);
    CustomAssert.IsNotNull(HUDPanel);
    CustomAssert.IsNotNull(PausePanel);
    //CustomAssert.IsNotNull(GameOverPanel);
    CustomAssert.IsNotNull(KeysText);
    CustomAssert.IsNotNull(GameOverText);
    CustomAssert.IsNotNull(WinPanel);

    CustomAssert.IsNotNull(CurrMaskIcon);
    CustomAssert.IsNotNull(FireMaskIcon);
    CustomAssert.IsNotNull(IceMaskIcon);
    CustomAssert.IsNotNull(InvisibilityMaskIcon);
    CustomAssert.IsNotNull(TruthMaskIcon);
    CustomAssert.IsNotNull(TeleportMaskIcon);
  }

  public void ShowPanel(GameObject panel, bool showHUD = false)
  {
    MainMenuPanel.SetActive(MainMenuPanel == panel);
    InstructionsPanel.SetActive(InstructionsPanel == panel);
    AudioPanel.SetActive(AudioPanel == panel);
    HUDPanel.SetActive(HUDPanel == panel || showHUD);
    PausePanel.SetActive(PausePanel == panel);
    GameOverPanel.SetActive(GameOverPanel == panel);
    WinPanel.SetActive(WinPanel == panel);
  }

  public void InfoUpdate()
  {

  }

  public void UpdateKeysText(int gotKeys)
  {
    KeysText.text = gotKeys + " / " + GameManager.Instance.WinZone.KeysNeeded;
  }

  public void AddMaskToInventory(Mask mask, bool isFirstMask = false)
  {
    mask.OnPowerChange += UpdateMaskPower;

    if (isFirstMask)
    {
      CurrMaskSliderGO.SetActive(true);
    }

    switch (mask.Type)
    {
      case MaskTypes.FIRE:
      {
        FireMaskSliderGO.SetActive(true);
        FireMaskFill.color = mask.MaskColor;
        FireMaskIcon.sprite = mask.SpriteRen.sprite;
        FireMaskIcon.color = Color.white;
        break;
      }
      case MaskTypes.ICE:
      {
        IceMaskSliderGO.SetActive(true);
        IceMaskFill.color = mask.MaskColor;
        IceMaskIcon.sprite = mask.SpriteRen.sprite;
        IceMaskIcon.color = Color.white;
        break;
      }
      case MaskTypes.INVISIBILITY:
      {
        InvisibilityMaskSliderGO.SetActive(true);
        InvisibilityMaskFill.color = mask.MaskColor;
        InvisibilityMaskIcon.sprite = mask.SpriteRen.sprite;
        InvisibilityMaskIcon.color = Color.white;
        break;
      }
      case MaskTypes.TRUTH:
      {
        TruthMaskSliderGO.SetActive(true);
        TruthMaskFill.color = mask.MaskColor;
        TruthMaskIcon.sprite = mask.SpriteRen.sprite;
        TruthMaskIcon.color = Color.white;
        break;
      }
      case MaskTypes.TELEPORT:
      {
        TeleportMaskSliderGO.SetActive(true);
        TeleportMaskFill.color = mask.MaskColor;
        TeleportMaskIcon.sprite = mask.SpriteRen.sprite;
        TeleportMaskIcon.color = Color.white;
        break;
      }
    }

    UpdateMaskPower(mask);
  }

  public void UpdateMaskPower(Mask mask)
  {
    Mask currMask = GameManager.Instance.Player.CurrMask;
    Sprite maskIcon = mask.SpriteRen.sprite;

    float normalizedPower = mask.CurrPower / mask.MaxPower;

    switch (mask.Type)
    {
      case MaskTypes.FIRE:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor, maskIcon);
        }
        FireMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.ICE:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor, maskIcon);
        }
        IceMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.INVISIBILITY:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor, maskIcon);
        }
        InvisibilityMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.TRUTH:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor, maskIcon);
        }
        TruthMaskSlider.value = normalizedPower;
        break;
      }
      case MaskTypes.TELEPORT:
      {
        if (currMask == mask)
        {
          UpdateCurrMaskPower(normalizedPower, mask.MaskColor, maskIcon);
        }
        TeleportMaskSlider.value = normalizedPower;
        break;
      }
    }
  }

  public void UpdateCurrMaskPower(float normalizedPower, Color sliderColor, Sprite maskIcon)
  {
    CurrMaskSlider.value = normalizedPower;
    Color opaqueSliderColor = sliderColor;
    opaqueSliderColor.a = 1.0f;
    CurrMaskFill.color = opaqueSliderColor;

    CurrMaskIcon.sprite = maskIcon;
    CurrMaskIcon.color = Color.white;
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
    GameManager.Instance.ResetGame();
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
