using UnityEngine;

public class AreaWinTrigger : MonoBehaviour
{
    public GameObject WinPanel; // Assign the loss panel GameObject in the inspector
    
    private void Start()
    {
        gameObject.SetActive(false); // Ensure the square area is deactivated at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fart")) 
        {
            
            WinPanel.SetActive(true);
            // If you have a game manager or other game control logic, you can call it here.
        }
    }
}
