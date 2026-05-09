using System.Collections;
using UnityEngine;

public class AnnoyingCompanion : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform player;
    public float orbitRadius = 3f;
    public float followSpeed = 5f;
    public float orbitSpeed = 90f;

    [Header("Jitter")]
    public float jitterInterval = 0.8f;
    public float jitterStrength = 2f;

    [Header("Grounding")]
    public float groundOffset = 0f;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip[] laughClips;
    public AudioClip[] screamClips;

    [Header("Timer Panic")]
    public float timerThreshold = 120f;

    private float orbitAngle = 0f;
    private Vector3 targetOffset;
    private Vector3 destination;
    private float jitterTimer;
    private bool isScreaming = false;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance != null)
            OnTimerUpdate(GameManager.Instance.GetTimeRemaining());
    }

    void FixedUpdate()
    {
        orbitAngle += orbitSpeed * Time.fixedDeltaTime;

        jitterTimer -= Time.fixedDeltaTime;
        if (jitterTimer <= 0f)
        {
            targetOffset = new Vector3(
                Random.Range(-jitterStrength, jitterStrength),
                0f,
                Random.Range(-jitterStrength, jitterStrength)
            );
            jitterTimer = jitterInterval;
        }

        float rad = orbitAngle * Mathf.Deg2Rad;
        Vector3 orbitPos = player.position + new Vector3(
            Mathf.Cos(rad) * orbitRadius,
            0f,
            Mathf.Sin(rad) * orbitRadius
        );

        destination = orbitPos + targetOffset;

        if (Physics.Raycast(destination + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 20f))
        {
            destination.y = hit.point.y + groundOffset;
        }

        float distToDestination = Vector3.Distance(transform.position, destination);

        // Animate based on speed
        bool moving = distToDestination > 0.1f;
        bool running = orbitSpeed > 200f; // runs when panicking

        animator.SetBool("isWalking", moving && !running);
        animator.SetBool("isRunning", moving && running);

        rb.MovePosition(Vector3.MoveTowards(
            transform.position, destination, followSpeed * Time.fixedDeltaTime
        ));

        transform.LookAt(new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z
        ));
    }

    void OnTimerUpdate(float remainingTime)
{
    Debug.Log("Time remaining: " + remainingTime); // check if this is being called

    if (remainingTime <= timerThreshold)
    {
        Debug.Log("Panic threshold reached!"); // check if threshold is hit

        if (!isScreaming)
        {
            isScreaming = true;
            animator.SetBool("isScreaming", true);
            Debug.Log("Starting scream loop..."); // check if coroutine starts
            StartCoroutine(ScreamLoop());
        }
    }
}

    IEnumerator ScreamLoop()
    {
        while (isScreaming)
        {
            Debug.Log("Scream clips count: " + screamClips.Length); // check clips are assigned
            Debug.Log("Audio source: " + audioSource);              // check audio source exists
            PlayRandom(screamClips);
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        }
    }

    public void LaughAtPlayer()
    {
        StopAllCoroutines();
        isScreaming = false;
        animator.SetBool("isScreaming", false);
        animator.SetBool("isDead", true); // plays death anim as "laugh taunt"
        PlayRandom(laughClips);
    }

    private void PlayRandom(AudioClip[] clips)
    {
        if (clips.Length == 0) return;
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }

    // Call this when player gets hit by something
public void OnPlayerHit()
{
    PlayRandom(laughClips);
}

// Call this when player dies
public void OnPlayerDeath()
{
    StopAllCoroutines();
    isScreaming = false;
    animator.SetBool("isScreaming", false);
    animator.SetBool("isWalking", false);
    animator.SetBool("isRunning", false);
    animator.SetBool("isFalling", true);
    PlayRandom(laughClips);
    StartCoroutine(TriggerDeath());
}

IEnumerator TriggerDeath()
{
    yield return new WaitUntil(() =>
        animator.GetCurrentAnimatorStateInfo(0).IsName("fall") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
    );
    animator.SetBool("isFalling", false);
    animator.SetBool("isDead", true);
}


    
}