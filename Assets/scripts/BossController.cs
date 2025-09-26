using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bossFarted;
    public GameObject bossMad; 
    public GameObject WinningPanel;// Assign the "Boss (Farted)" GameObject in the inspector

    void OnDestroy()
    {
        if (bossFarted != null)
        {
            bossFarted.SetActive(true);
            bossMad.SetActive(false);
            WinningPanel.SetActive(true);
            StopGame();
        }
    }

    // Call this method to destroy the boss (for example, when its health reaches zero)
    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
    private void StopGame()
    {
        Time.timeScale = 0;
        // If you have additional logic to fully end the game, like going back to the main menu,
        // you can add it here.
    }
}
