using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomMovementController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float decisionDelay = 1.5f;

    private Vector2 targetPosition;
    private bool isMoving;
    private bool isDead = false;

    [Header("Collision")]
    public LayerMask obstacleLayer;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private float timer;
    private AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;

        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null)
        {
            audioManager = audioObj.GetComponent<AudioManager>();
        }
    }

    private void Start()
    {
        targetPosition = RoundToGrid(transform.position);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (!isMoving && timer <= 0f)
        {
            ChooseNextMove();
            timer = decisionDelay;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime));

            if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
            {
                rb.MovePosition(targetPosition);
                isMoving = false;

                activeSpriteRenderer.idle = true;
            }
        }
    }

    private void ChooseNextMove()
    {
        Vector2[] directions = {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        // Shuffle directions
        for (int i = 0; i < directions.Length; i++)
        {
            Vector2 temp = directions[i];
            int rand = Random.Range(i, directions.Length);
            directions[i] = directions[rand];
            directions[rand] = temp;
        }

        foreach (var dir in directions)
        {
            Vector2 nextPos = RoundToGrid(rb.position + dir);

            if (!Physics2D.OverlapCircle(nextPos, 0.2f, obstacleLayer))
            {
                targetPosition = nextPos;
                isMoving = true;

                SetDirection(dir);
                return;
            }
        }

        SetDirection(Vector2.zero);
    }

    private Vector2 RoundToGrid(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    private void SetDirection(Vector2 newDirection)
    {
        if (newDirection == Vector2.up)
            SetSprite(spriteRendererUp);
        else if (newDirection == Vector2.down)
            SetSprite(spriteRendererDown);
        else if (newDirection == Vector2.left)
            SetSprite(spriteRendererLeft);
        else if (newDirection == Vector2.right)
            SetSprite(spriteRendererRight);
        else
            activeSpriteRenderer.idle = true;
    }

    private void SetSprite(AnimatedSpriteRenderer sprite)
    {
        spriteRendererUp.enabled = sprite == spriteRendererUp;
        spriteRendererDown.enabled = sprite == spriteRendererDown;
        spriteRendererLeft.enabled = sprite == spriteRendererLeft;
        spriteRendererRight.enabled = sprite == spriteRendererRight;

        activeSpriteRenderer = sprite;
        activeSpriteRenderer.idle = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead && other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        if (isDead) return;
        isDead = true;

        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.EDeath);
        }

        ScoreManager.Instance.AddScore(10);

        enabled = false;
        
        GetComponent<Collider2D>().enabled = false;

        // Disable movement visuals
        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;

        // Enable death animation
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        GameManager.Instance.CheckWinState();
    }
}