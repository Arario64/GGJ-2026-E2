using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{

    private void Update()
    {       

        //---MUSIC-- -
        if (Inputs.Running())
        {
            AudioManager.Instance.PlayMusic(MusicTag.Running);
        }
        if (Inputs.MenuMusic())
        {
            AudioManager.Instance.PlayMusic(MusicTag.Menu);
        }

        //// --- SFX ---
        if (Inputs.Jump())
        {
            AudioManager.Instance.PlaySfx(SFXTag.Jump);
        }
        //if (Inputs.Key())
        //{
        //    AudioManager.Instance.PlaySfx(SFXTag.Key);
        //}
        //if (Inputs.Hurt())
        //{
        //    AudioManager.Instance.PlaySfx(SFXTag.Hurt);
        //}

        // --- VOLUMENES ---
        // Música
        if (Inputs.increase())
        {
            AudioManager.Instance.IncreaseMusic();
        }
        if (Inputs.decrease())
        {
            AudioManager.Instance.DecreaseMusic();
        }

        // Main
        if (Inputs.increaseMain())
        {
            AudioManager.Instance.IncreaseMain();
        }
        if (Inputs.decreaseMain())
        {
            AudioManager.Instance.DecreaseMain();
        }

        // SFX
        if (Inputs.increaseSFX())
        {
            AudioManager.Instance.IncreaseSFX();
        }
        if (Inputs.decreaseSFX())
        {
            AudioManager.Instance.DecreaseSFX();
        }
    }

}
