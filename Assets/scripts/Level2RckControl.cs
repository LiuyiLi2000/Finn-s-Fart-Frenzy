using System.Collections;
using UnityEngine;

public class Level2RckControl : MonoBehaviour
{
    
    public GameObject LosingPanel;
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
        PauseGame();
    }

    

    void ActivateLosingPanel()
    {
        

        isTimerActive = false;
        LosingPanel.SetActive(true);
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}