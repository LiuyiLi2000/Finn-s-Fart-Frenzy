using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Image

public class IdleImageActivator : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; // Assign your player's Rigidbody2D in the inspector
    public GameObject idleImage; // Assign the GameObject with the image component in the inspector
    public float idleTime = 3f; // Time in seconds to wait before showing the image

    private float timer = 0f;

    void Update()
    {
        // Check if the player is moving
        if (playerRigidbody.velocity.magnitude > 0.01f) // Adjust this threshold as needed
        {
            timer = 0f; // Reset the timer if the player is moving
            idleImage.SetActive(false); // Hide the image
        }
        else
        {
            timer += Time.deltaTime; // Increment the timer when the player is not moving

            if (timer >= idleTime)
            {
                idleImage.SetActive(true); // Show the image when the timer reaches the threshold
            }
        }
    }
}

