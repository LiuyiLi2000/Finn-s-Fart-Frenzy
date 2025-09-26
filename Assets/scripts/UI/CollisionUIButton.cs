using UnityEngine;
using UnityEngine.UI;

public class CollisionUIButton : MonoBehaviour
{
    public GameObject uiButton; // Assign this in the inspector

    private void Start()
    {
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false); // Initially hide the button
        }
    }

    // This method is called when the collider enters a collision
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            if (uiButton != null)
            {
                uiButton.gameObject.SetActive(true); // Show the button
            }
        }
    }

    // This method is called when the collider exits a collision
    private void OnCollisionExit(Collision collision)
    {
        // Check if the collision was with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            if (uiButton != null)
            {
                uiButton.gameObject.SetActive(false); // Hide the button
            }
        }
    }
}

