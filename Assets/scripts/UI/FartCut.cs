using UnityEngine;
using System.Collections;

public class FartCut : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; // Assign the player's Rigidbody2D in the inspector
    public GameObject cutscene; // Assign the cutscene GameObject in the inspector
    private float idleTime = 5f; // Time player needs to be idle for the cutscene to show
    private float cutsceneDuration = 1f; // Duration for which the cutscene is shown
    private float timer = 0f;

    void Update()
    {
        // Check if the player is moving
        if (playerRigidbody.velocity.magnitude < 0.01f) // Adjust this threshold as needed
        {
            timer += Time.deltaTime; // Increment the timer when the player is idle

            if (timer >= idleTime)
            {
                // Show the cutscene and start the coroutine to hide it after 1 second
                cutscene.SetActive(true);
                StartCoroutine(HideCutsceneAfterDelay(cutsceneDuration));
                timer = 0f; // Reset the timer
            }
        }
        else
        {
            // Reset the timer if the player is moving
            timer = 0f;
        }
    }

    private IEnumerator HideCutsceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cutscene.SetActive(false); // Hide the cutscene after the delay
    }
}


