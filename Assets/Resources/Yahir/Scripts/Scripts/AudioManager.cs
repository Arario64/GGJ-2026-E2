using UnityEngine;

public enum MusicTag
{
    Running = 0,
    Menu,
    Die,
    Mazmorra_01,
    Mazmorra_02,
    Mazmorra_03,
    Victory_01,
    Victory_02,

}

public enum SFXTag
{
    Jump = 0,
    Key,
    Hurt,
    Cash,
    Purchase,
    NotMoney,
    Explosion_01,
    Explosion_02,
    Laser_01,
    Deth,
    Achievement_01,
    Achievement_02
}

public class AudioManager : Singletone<AudioManager>
{
    public MainAudio mainAudioRef;
    public MusicAudio musicAudioRef;
    public SFXAudio sfxAudioRef;

    public static MainAudio mainAudio;
    public static MusicAudio musicAudio;
    public static SFXAudio sfxAudio;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != this) return;

        mainAudio = mainAudioRef;
        musicAudio = musicAudioRef;
        sfxAudio = sfxAudioRef;

        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (mainAudio == null || musicAudio == null ||
 sfxAudio == null)
            return;
        // aplicamos la mezcla de volúmenes
        musicAudio.ApplyVolume(mainAudio.mainVolume);
        sfxAudio.ApplyVolume(mainAudio.mainVolume);
    }

    //---musicAudio--
    public void PlayMusic(MusicTag tag) => musicAudio.Play(tag);
    public void StopMusic() => musicAudio.Stop();

    //---sfxAudio--
    public void PlaySfx(SFXTag tag) => sfxAudio.Play(tag);
    public void StopSfx() => sfxAudio.Stop();

    //---mainAudio--
    public void IncreaseMain() => mainAudio.Increase();
    public void DecreaseMain() => mainAudio.Decrease();

    //---musicAudio--
    public void IncreaseMusic() => musicAudio.Increase();
    public void DecreaseMusic() => musicAudio.Decrease();

    //---sfxAudio--
    public void IncreaseSFX() => sfxAudio.Increase();
    public void DecreaseSFX() => sfxAudio.Decrease();

}
