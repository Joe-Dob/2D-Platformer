using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform respawnPoint;

    public static RespawnController Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.position = respawnPoint.position;
        }
    }
}
