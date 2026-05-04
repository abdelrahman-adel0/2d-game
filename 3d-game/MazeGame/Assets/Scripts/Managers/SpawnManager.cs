using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;

    void Start()
    {
        player.transform.position = spawnPoint.position;
    }
}