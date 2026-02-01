using UnityEngine;
using UnityEngine.UI;

public class UI_AudioSlider : MonoBehaviour
{
    public enum AudioType { Main, Music, SFX }

    [SerializeField] private AudioType type;
    [SerializeField] private Slider slider;

    private string prefsKey;

    private void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();
                
        prefsKey = "Volume_" + type.ToString(); // Clave única

        float savedVolume = PlayerPrefs.GetFloat(prefsKey, 1f);
        slider.value = savedVolume;
                
        ApplyVolume(savedVolume);// Aplicar al AudioManager
                
        slider.onValueChanged.AddListener(OnSliderValueChanged);// Suscribir evento
    }

    private void OnSliderValueChanged(float value)
    {
        ApplyVolume(value);

        // Guardar en PlayerPrefs
        PlayerPrefs.SetFloat(prefsKey, value);
        PlayerPrefs.Save();
    }

    private void ApplyVolume(float value)
    {
        switch (type)
        {
            case AudioType.Main:
                AudioManager.mainAudio.mainVolume = value;
                break;
            case AudioType.Music:
                AudioManager.musicAudio.musicVolume = value;
                break;
            case AudioType.SFX:
                AudioManager.sfxAudio.sfxVolume = value;
                break;
        }
    }
}



