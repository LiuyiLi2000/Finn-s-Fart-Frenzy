using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float initialTime = 44f; // Total time in seconds
    public float timeRemaining; // Time remaining
    public GameObject losingPanel;
    public GameObject winningPanel;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timeRemaining = initialTime; // Initialize the remaining time
    }

    private void Update()
    {
        if (winningPanel.activeInHierarchy)
        {
            Time.timeScale = 0f;
            return; // Skip the rest of the Update if the winning panel is active
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "0%";
            this.enabled = false; // Disable the script after game over
        }
    }

    void UpdateTimerDisplay()
    {
        float percentage = (timeRemaining / initialTime) * 100f;
        timerText.text = percentage.ToString("0") + "%"; // Display as an integer percentage

        // Change text color to red if below 20%, otherwise use default color
        if (percentage <= 20f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.black; // Assuming default color is white
        }
    }
}



