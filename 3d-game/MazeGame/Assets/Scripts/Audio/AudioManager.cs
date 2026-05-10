using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Background Music")]
    public AudioClip BackgroundMusic;

    [Header("SFX Clips")]
    public AudioClip ButtonClick;
    public AudioClip Walk;
    public AudioClip WallHit;
    public AudioClip SpawnSFX;
    public AudioClip DeathHit;
    public AudioClip LoseLaugh;
    public AudioClip PumpkinLaugh;
    public AudioClip WallMovement;

    private void Awake()
    {
        // Singleton pattern — persist across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic();
    }

    // ── Music ──────────────────────────────────────────────────────────────

    public void PlayMusic()
    {
        Debug.Log("musicSource: " + musicSource);
        Debug.Log("BackgroundMusic: " + BackgroundMusic);
    
        if (musicSource == null || BackgroundMusic == null) return;

        if (musicSource.isPlaying)
        {
            musicSource.clip = BackgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }

    // ── SFX ───────────────────────────────────────────────────────────────

    /// <summary>Plays any one-shot SFX clip.</summary>
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    /// <summary>Convenience wrapper used by every UI button.</summary>
    public void PlayButtonClick()
    {
        PlaySFX(ButtonClick);
    }

    // ── Volume helpers (optional, hook these up to a settings UI) ─────────

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = Mathf.Clamp01(volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
            sfxSource.volume = Mathf.Clamp01(volume);
    }

    public bool IsSFXPlaying()
{
    return sfxSource.isPlaying;
}
    
}

