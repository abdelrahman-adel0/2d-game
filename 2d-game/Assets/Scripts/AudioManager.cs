using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip Death;
	public AudioClip EDeath;
    public AudioClip Explosion;
	public AudioClip Win;

	public void PlayWin()
	{
    	musicSource.Stop();
    	SFXSource.PlayOneShot(Win);
	}

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == Death)
        {
            musicSource.Stop();
        }

        SFXSource.PlayOneShot(clip);
    }
}