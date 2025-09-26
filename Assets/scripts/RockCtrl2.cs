using System.Collections;
using UnityEngine;

public class RockCtrl2: MonoBehaviour
{
    public GameObject WinningPanel;
    public GameObject LosingPanel;
    public GameObject OtherPanel; // Reference to the Other Panel
    public PlayerMovement playerMovement;

    private float timer = 4.0f;
    private bool isTimerActive = true;

    void Update()
    {
        if (isTimerActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                ActivateLosingPanel();
            }
        }
    }

    public void CustomDestroy()
    {
        Destroy(gameObject);
        ActivateWinningPanel();
    }

    void ActivateWinningPanel()
    {
        isTimerActive = false;

        WinningPanel.SetActive(true);
        PauseGame();
        LosingPanel.SetActive(false);
    }

    void ActivateLosingPanel()
    {
        // Check if Other Panel is active
        if (OtherPanel != null && OtherPanel.activeSelf)
        {
            // If Other Panel is active, do not activate Losing Panel
            return;
        
        }

        isTimerActive = false;
        LosingPanel.SetActive(true);
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
