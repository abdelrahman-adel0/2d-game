using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------ Audio Clip --------------")]

    public AudioClip MusicAudio;
    public AudioClip DeathHitSFX;
    public AudioClip SpawnSFX;
    public AudioClip WalkSFX;
    public AudioClip WallHitSFX;
    public AudioClip LoseLaughSFX;
    public AudioClip PumpkinLaughSFX;




}
