using UnityEngine;

public class WallHit : MonoBehaviour
{
    public float cooldown = 0.5f;
    private float cooldownTimer = 0f;

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Ignore floor and ceiling, only walls
        if (hit.normal.y > 0.5f || hit.normal.y < -0.5f) return;

        if (cooldownTimer <= 0f)
        {
            AudioManager.Instance?.PlaySFX(AudioManager.Instance.WallHit);
            cooldownTimer = cooldown;
        }
    }
}