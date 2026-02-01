using UnityEngine;

public class SFXAudio : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [Range(0f, 1f)]
    public float sfxVolume = 1f;

    public SerializableDictionary<SFXTag, AudioClip> sfxTags;

    public void Play(SFXTag tag)
    {
        var clip = sfxTags[tag];
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void Stop()
    {
        sfxSource.Stop();
    }

    public void Increase()
    {
        sfxVolume = Mathf.Clamp01(sfxVolume + 0.05f);
    }

    public void Decrease()
    {
        sfxVolume = Mathf.Clamp01(sfxVolume - 0.05f);
    }

    public void ApplyVolume(float mainVolume)
    {
        sfxSource.volume = mainVolume * sfxVolume;
    }
}
