using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    public GameObject pausePanel; // Assign the pause panel in the inspector

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
