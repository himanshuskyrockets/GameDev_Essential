using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image muteButtonImage;
    [SerializeField] private Image unmuteButtonImage;
    [SerializeField] private TMP_Text audioText;

    private bool isMuted = false;

    public void OnAudioButtonClick()
    {
        ToggleMute();
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        audioSource.mute = isMuted;
        muteButtonImage.gameObject.SetActive(!isMuted);
        unmuteButtonImage.gameObject.SetActive(isMuted);
        audioText.text = isMuted ? "Sound" : "Mute";
    }
   
}
