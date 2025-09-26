using UnityEngine;
using UnityEngine.UI;

public class CircleBar : MonoBehaviour
{
    public Image circularBar;  // Reference to the circular fill bar UI
    public float holdTimeToReleaseFart = 1f;  // Time required to hold the key

    private float currentHoldTime = 0f;
    private bool isFarting = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Increase the timer if space key is held
            currentHoldTime += Time.deltaTime;

            // Update the UI bar
            circularBar.fillAmount = currentHoldTime / holdTimeToReleaseFart;

            // If held for enough time
            if (currentHoldTime >= holdTimeToReleaseFart && !isFarting)
            {
                Fart();
                isFarting = true;  // To prevent multiple farts in one hold
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space) || !Input.GetKey(KeyCode.Space))
        {
            // Reset timer and UI bar when key is released or not held
            currentHoldTime = 0f;
            circularBar.fillAmount = 0f;
            isFarting = false;
        }
    }

    void Fart()
    {
        // Place your farting logic here
    }
}

