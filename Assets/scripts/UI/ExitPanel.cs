using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour

{
    public GameObject exitPanel;
    public GameObject PausePanel; // Assign the Exit Panel in the inspector

   public void ToggleExitPanel()
    {
        // Toggle the exit panel
        if (exitPanel != null)
        {
            bool isExitPanelActive = exitPanel.activeSelf;
            exitPanel.SetActive(!isExitPanelActive);
        }
        else
        {
            Debug.LogError("ExitPanel is not assigned in the inspector!");
        }

        // Deactivate the pause panel
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("PausePanel is not assigned in the inspector!");
        }
    }
}