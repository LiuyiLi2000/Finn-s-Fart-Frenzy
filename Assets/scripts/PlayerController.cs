using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovementScript; // Assign this in the inspector
    private float keyHoldTime = 0f;

    void Update()
    {
        // Check if the space key is being held down
        if (Input.GetKey(KeyCode.Space))
        {
            keyHoldTime += Time.deltaTime;

            // If the key is held for 0.8 seconds, disable the player movement script
            if (keyHoldTime >= 0.7f)
            {
                playerMovementScript.enabled = false;
            }
        }

        // Reset the key hold time and re-enable movement if the space key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            keyHoldTime = 0f;
            playerMovementScript.enabled = true;
        }
    }
}
