using UnityEngine;

public class MainAudio : MonoBehaviour
{
    [Range(0f, 1f)]
    public float mainVolume = 1f;

    public void Increase()
    {
        mainVolume = Mathf.Clamp01(mainVolume + 0.05f);
    }

    public void Decrease()
    {
        mainVolume = Mathf.Clamp01(mainVolume - 0.05f);
    }
}
