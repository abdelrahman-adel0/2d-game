using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.down;
	private bool isDead = false;
    public float speed = 5f;

    [Header("Input")]
    public InputActionReference moveAction; // 👈 assign in Inspector

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
    
    AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Normalize to 4 directions (like your original logic)
        if (input.y > 0.5f)
            SetDirection(Vector2.up, spriteRendererUp);
        else if (input.y < -0.5f)
            SetDirection(Vector2.down, spriteRendererDown);
        else if (input.x < -0.5f)
            SetDirection(Vector2.left, spriteRendererLeft);
        else if (input.x > 0.5f)
            SetDirection(Vector2.right, spriteRendererRight);
        else
            SetDirection(Vector2.zero, activeSpriteRenderer);
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = speed * Time.fixedDeltaTime * direction;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
    	if (isDead) return;

    	if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") ||
        	other.CompareTag("Enemy"))
    	{
        	DeathSequence();
    	}
	}

    private void DeathSequence()
	{
    	if (isDead) return;
    	isDead = true;

    	enabled = false;
    	GetComponent<BombController>().enabled = false;

    	spriteRendererUp.enabled = false;
    	spriteRendererDown.enabled = false;
    	spriteRendererLeft.enabled = false;
    	spriteRendererRight.enabled = false;
    	spriteRendererDeath.enabled = true;

    	Invoke(nameof(OnDeathSequenceEnded), 1.25f);
	}

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        GameManager.Instance.LoseGame();
    }

}
