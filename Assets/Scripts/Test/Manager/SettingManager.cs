using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource backgroundMusic; 

    [Header("Button Settings")]
    public Button muteButton;           
    public Sprite muteSprite;           
    public Sprite unmuteSprite;         
    private bool isMuted = false;

    private void Start()
    {
        // Load saved mute state
        isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        UpdateAudioState();
    }

    // Called when the mute/unmute button is clicked
    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0); // Save state
        PlayerPrefs.Save();
        UpdateAudioState();
    }

    // Update the music and button sprite
    private void UpdateAudioState()
    {
        backgroundMusic.mute = isMuted; // Mute or unmute the audio source
        muteButton.image.sprite = isMuted ? muteSprite : unmuteSprite; // Change button sprite
    }
    public void QuitGameClick()
    {
        Application.Quit();
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
