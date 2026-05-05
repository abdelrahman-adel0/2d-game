using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if it's the player
        if (other.CompareTag("Player"))
        {
            // Tell GameManager a key was collected
            GameManager.Instance.KeyCollected();

            // Destroy the key
            Destroy(gameObject);
        }
    }
}