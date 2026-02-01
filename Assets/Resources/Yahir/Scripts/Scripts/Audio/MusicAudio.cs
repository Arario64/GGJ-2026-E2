using UnityEngine;

public class MusicAudio : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [Range(0f, 1f)]
    public float musicVolume = 1f;

    public SerializableDictionary<MusicTag, AudioClip> musicTags;

    public void Play(MusicTag tag)
    {
        var clip = musicTags[tag];
        if (musicSource.clip == clip)
        {
            return;
        }            

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void Stop()
    {
        musicSource.Stop();
    }

    public void Increase()
    {
        musicVolume = Mathf.Clamp01(musicVolume + 0.05f);
    }

    public void Decrease()
    {
        musicVolume = Mathf.Clamp01(musicVolume - 0.05f);
    }

    public void ApplyVolume(float mainVolume)
    {
        musicSource.volume = mainVolume * musicVolume;
    }
}
