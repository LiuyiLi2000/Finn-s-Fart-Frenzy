using UnityEngine;
using UnityEngine.UI; // Needed for UI elements

public class PlayerWinningScript : MonoBehaviour
{
    public float stillnessTime = 5f; // Time player needs to stand still
    private float stillnessTimer = 0f;

    public GameObject winningPanel; // Assign this in the inspector

    void Update()
    {
        // Check for player movement
        float movement = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
        if (movement > 0.01f) // Threshold for movement detection
        {
            stillnessTimer = 0f; // Reset the stillness timer if there's movement
        }
        else
        {
            stillnessTimer += Time.deltaTime;
            if (stillnessTimer >= stillnessTime)
            {
                ShowWinningPanel(); // Show the winning panel after 6 seconds of stillness
                stillnessTimer = 0f; // Reset timer or disable the script to prevent multiple triggers
            }
        }
    }

    void ShowWinningPanel()
    {
        winningPanel.SetActive(true); // Activate the winning panel
    }
}
