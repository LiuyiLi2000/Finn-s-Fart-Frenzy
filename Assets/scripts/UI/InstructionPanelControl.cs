using UnityEngine;

public class InstructionPanelControl : MonoBehaviour
{
    public GameObject instructionPanel; 

    private void Start()
    {
        if (instructionPanel.activeSelf)
        {
            Invoke("HideInstructionPanel", 5f); 
        }
    }

    private void HideInstructionPanel()
    {
        instructionPanel.SetActive(false);
    }
}


