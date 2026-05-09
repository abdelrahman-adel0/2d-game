using UnityEngine;

public class WalkSFX : MonoBehaviour
{
    [Header("Settings")]
    public float stepInterval = 0.5f; // time between footstep sounds
    private float stepTimer = 0f;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Only play if grounded and actually moving
        if (cc != null && cc.isGrounded && cc.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                AudioManager.Instance?.PlaySFX(AudioManager.Instance.Walk);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f; // reset so first step plays immediately
        }
    }
}