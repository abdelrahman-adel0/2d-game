using UnityEngine;

/// <summary>
/// Attach to the Pumpkin GameObject.
/// Uses distance-based proximity — no trigger collider needed,
/// so your existing Mesh Collider can stay as-is.
///
/// Requires:
///   - An AudioSource component (auto-added via RequireComponent)
///   - The Player to be findable by tag (default "Player")
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PumpkinLaugh : MonoBehaviour
{
    [Header("Detection")]
    [Tooltip("Radius (in world units) within which the pumpkin laughs.")]
    public float laughRadius = 5f;

    [Tooltip("Must match the tag on your Player GameObject.")]
    public string playerTag = "Player";

    [Header("Laugh Settings")]
    [Tooltip("Leave empty — auto-filled from AudioManager.PumpkinLaugh.")]
    public AudioClip laughClip;

    [Range(0f, 1f)]
    public float volume = 1f;

    // Dedicated AudioSource so Stop() works independently of the shared SFX channel
    private AudioSource _audioSource;
    private Transform   _player;
    private bool        _isLaughing;

    private void Awake()
    {
        _audioSource              = GetComponent<AudioSource>();
        _audioSource.playOnAwake  = false;
        _audioSource.loop         = true;   // keeps laughing while player is close
        _audioSource.volume       = volume;
        _audioSource.spatialBlend = 1f;     // full 3-D audio — fades with distance
    }

    private void Start()
    {
        // Auto-fetch clip from AudioManager if none assigned in Inspector
        if (laughClip == null && AudioManager.Instance != null)
            laughClip = AudioManager.Instance.PumpkinLaugh;

        _audioSource.clip = laughClip;

        // Cache the player transform once at start
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            _player = playerObj.transform;
        else
            Debug.LogWarning($"PumpkinLaugh: No GameObject with tag '{playerTag}' found.", this);
    }

    private void Update()
    {
        if (_player == null || laughClip == null) return;

        float dist = Vector3.Distance(transform.position, _player.position);
        bool inRange = dist <= laughRadius;

        // Player just entered range → start laughing
        if (inRange && !_isLaughing)
        {
            _audioSource.Play();
            _isLaughing = true;
        }
        // Player just left range → stop laughing
        else if (!inRange && _isLaughing)
        {
            _audioSource.Stop();
            _isLaughing = false;
        }
    }

    // ── Draw the laugh radius in the Editor as a yellow wire-sphere ───────
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, laughRadius);
    }
}
