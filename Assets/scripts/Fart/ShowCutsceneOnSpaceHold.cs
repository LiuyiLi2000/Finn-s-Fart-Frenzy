using UnityEngine;
using System.Collections;

public class ShowCutsceneOnSpaceHold : MonoBehaviour
{
    public GameObject cutscene; // Assign the cutscene GameObject in the inspector
    private float spaceHoldTime = 0.8f; // Time player needs to hold space for the cutscene to show
    private float cutsceneDuration = 1f; // Duration for which the cutscene is shown
    private float spaceTimer = 0f;
    private bool isSpacePressed = false;

    void Update()
    {
        // Check if the space key is being held down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
            spaceTimer = 0; // Reset the timer
        }

        if (isSpacePressed)
        {
            spaceTimer += Time.deltaTime; // Increment the timer

            if (spaceTimer >= spaceHoldTime)
            {
                // Show the cutscene and start the coroutine to hide it after 1 second
                cutscene.SetActive(true);
                StartCoroutine(HideCutsceneAfterDelay(cutsceneDuration));
                isSpacePressed = false; // Reset space key status
            }
        }

        // Check if the space key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
            spaceTimer = 0f; // Reset the timer
        }
    }

    private IEnumerator HideCutsceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cutscene.SetActive(false); // Hide the cutscene after the delay
    }
}

