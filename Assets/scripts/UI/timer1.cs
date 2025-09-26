using UnityEngine;
using TMPro; // Required for TextMeshPro elements
using System.Collections;

public class timer1 : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign your TextMeshProUGUI component in the Inspector
    private float timerDuration = 46f;
    private Coroutine countdownCoroutine; // To keep track of the running coroutine

    private void Start()
    {
        countdownCoroutine = StartCoroutine(StartCountdown(timerDuration));
    }

    private IEnumerator StartCountdown(float duration)
    {
        float countdown = duration;

        while (countdown > 0)
        {
            countdown -= Time.deltaTime;
            UpdateTimerDisplay(Mathf.Ceil(countdown)); // Update display every second
            yield return null;
        }

        OnCountdownFinished();
    }

    private void UpdateTimerDisplay(float currentTime)
    {
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("0"); // Display time as a whole number
        }
    }

    private void OnCountdownFinished()
    {
        // Code to execute after the countdown
        Debug.Log("Countdown finished!");
        if (timerText != null)
        {
            timerText.text = "Time's up!";
        }
    }

    // Method to increase the timer and restart the countdown
    public void IncreaseTimerAndRestart(float additionalTime)
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine); // Stop the current countdown
        }
        
        timerDuration += additionalTime; // Increase the timer duration
        countdownCoroutine = StartCoroutine(StartCountdown(timerDuration)); // Restart with new duration
    }
}

