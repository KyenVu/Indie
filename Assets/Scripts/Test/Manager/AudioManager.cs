using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource backgroundMusic;
    public AudioClip backgroundClip; 
    public bool loopMusic = true;       

    private static AudioManager instance; 

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void Start()
    {
        // Setup and start playing music
        if (backgroundMusic != null && backgroundClip != null)
        {
            backgroundMusic.clip = backgroundClip;
            backgroundMusic.loop = loopMusic;
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager is missing an AudioSource or AudioClip!");
        }
    }
}
