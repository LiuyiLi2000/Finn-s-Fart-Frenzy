using UnityEngine;
using System.Collections; // Required for using Coroutines

public class NPCReaction : MonoBehaviour
{
    public GameObject lossPanel; // Assign the loss panel GameObject in the inspector
    public GameObject cutScene; // Assign the cut scene GameObject in the inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fart"))
        {
            // Activate the cut scene
            cutScene.SetActive(true);

            // Start the coroutine to wait for 2 seconds
            StartCoroutine(WaitAndShowLossPanel());
        }
    }

    private IEnumerator WaitAndShowLossPanel()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Deactivate the cut scene
        cutScene.SetActive(false);

        // Activate the loss panel
        lossPanel.SetActive(true);

        // Optionally, pause the game or perform other loss-related actions here
        // If you have a game manager, you might want to call a method on it instead
        // GameManager.Instance.PlayerLost();
    }
}


