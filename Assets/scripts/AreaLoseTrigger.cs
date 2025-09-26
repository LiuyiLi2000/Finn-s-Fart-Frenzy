using UnityEngine;

public class AreaLoseTrigger : MonoBehaviour
{
    public GameObject lossPanel; // Assign the loss panel GameObject in the inspector
    
    private void Start()
    {
        gameObject.SetActive(false); // Ensure the square area is deactivated at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming the player GameObject has the tag "Player"
        {
            // Show the loss panel and handle the loss condition
            lossPanel.SetActive(true);
            // If you have a game manager or other game control logic, you can call it here.
        }
        if (lossPanel.activeInHierarchy)
    {
        StopGame();
    }
}

private void StopGame()
{
    Time.timeScale = 0;
}
    }

