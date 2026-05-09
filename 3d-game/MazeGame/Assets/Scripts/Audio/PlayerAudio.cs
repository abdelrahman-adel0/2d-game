using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        bool isMoving = Vector3.Distance(transform.position, lastPosition) > 0.001f;

        if (isMoving && !AudioManager.Instance.IsSFXPlaying())
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.Walk);
        }

        lastPosition = transform.position;
    }
}