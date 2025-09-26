using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel; // Assign the pause panel in the inspector

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
