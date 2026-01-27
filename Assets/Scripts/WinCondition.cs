using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private WinUIManager winUIManager;
    private bool hasWon = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasWon) return;

        if (other.CompareTag("Player"))
        {
            hasWon = true;
            winUIManager.ShowWinScreen();
        }
    }
}



