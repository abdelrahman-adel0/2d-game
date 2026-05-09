using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if it's the player
        if (other.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFX(AudioManager.Instance.SpawnSFX);
                
            // Tell GameManager a key was collected
            GameManager.Instance.KeyCollected();

            // Destroy the key
            Destroy(gameObject);
        }
    }
}