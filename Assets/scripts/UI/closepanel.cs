using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject instructionPanel; // Reference to the instruction panel

    public void CloseInstructionPanel()
    {
        // Deactivate the instruction panel
        instructionPanel.SetActive(false);
    }
}

