using JetBrains.Annotations;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleCounter.instance.Add(value);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 180f * Time.deltaTime);
    }
}
