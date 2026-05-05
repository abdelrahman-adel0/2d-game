using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            // Stop player movement
            FirstPersonController fpc = other.GetComponent<FirstPersonController>();
            if (fpc != null)
                fpc.playerCanMove = false;

            // Tell GameManager player won
            GameManager.Instance.WinGame();
        }
    }
}