using UnityEngine;

public class WalkSFX : MonoBehaviour
{
    [Header("Settings")]
    public float stepInterval = 0.5f;
    private float stepTimer = 0f;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        bool isMoving = Vector3.Distance(transform.position, lastPosition) > 0.001f;

        if (isMoving)
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
            stepTimer = 0f;
        }

        lastPosition = transform.position;
    }
}