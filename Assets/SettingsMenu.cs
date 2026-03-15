using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetVolume(float volume) {
        mainMixer.SetFloat("volume", volume);
    }
}
