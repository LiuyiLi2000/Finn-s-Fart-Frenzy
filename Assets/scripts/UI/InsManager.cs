using UnityEngine;

public class InsManager : MonoBehaviour
{
    void Start()
    {
        // Pauses the game at the start
        Time.timeScale = 0;
    }

    // Method to resume the game
    public void StartGame()
    {
        Time.timeScale = 1;
    }
}



