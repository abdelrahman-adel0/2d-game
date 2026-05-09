using UnityEngine;
using TMPro;

public class PlayerHitDetector : MonoBehaviour
{
    [Header("References")]
    public AnnoyingCompanion companion;
    public Transform skeleton;              // drag M_Skeleton here
    public TextMeshProUGUI livesText;

    [Header("Hit Settings")]
    public int maxHits = 3;
    public float hitCooldown = 1.5f;
    public float skeletonHitDistance = 1.2f; // how close skeleton has to be to hurt player

    private int hitCount = 0;
    private float hitCooldownTimer = 0f;
    private bool isDead = false;

    void Start()
    {
        UpdateLivesUI();
    }

    void Update()
    {
        if (isDead) return;

        if (hitCooldownTimer > 0f)
            hitCooldownTimer -= Time.deltaTime;

        // Check if skeleton is close enough to hit player
        if (skeleton != null && hitCooldownTimer <= 0f)
        {
            float dist = Vector3.Distance(transform.position, skeleton.position);
            if (dist <= skeletonHitDistance)
            {
                RegisterHit();
            }
        }
    }

    // Keep obstacle collision too
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isDead) return;
        if (hitCooldownTimer > 0f) return;
        if (hit.gameObject.CompareTag("Obstacle"))
            RegisterHit();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;
        if (hitCooldownTimer > 0f) return;
        if (collision.gameObject.CompareTag("Obstacle"))
            RegisterHit();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + (maxHits - hitCount);
    }

    void RegisterHit()
    {
        hitCount++;
        hitCooldownTimer = hitCooldown;
        Debug.Log("Player hit! " + hitCount + "/" + maxHits);
        companion?.OnPlayerHit();
        UpdateLivesUI();

        if (hitCount >= maxHits)
            PlayerDies();
    }

    void PlayerDies()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("Player died!");
        companion?.OnPlayerDeath();
        GameManager.Instance?.LoseGame();
    }
   
}