using UnityEngine;

public class WinUIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // pauses the whole game
    }
}

