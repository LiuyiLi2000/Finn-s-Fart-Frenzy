using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float rotationSpeed;
    public Vector2 detectionBoxSize; // Size of the detection box
    public LayerMask detectionLayer; // Layer mask to filter which objects are detected
    public GameObject WinningPanel;
    public GameObject LosingPanel;
    public GameObject CutScene;
    public static bool GameIsPaused = false;
    
    

    void Update()
    {
        // Rotate the boss
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
        // Define the center of the box relative to the Boss's position
        Vector3 boxCenter = transform.position + transform.right * detectionBoxSize.x / 2;

        // Check for colliders within the box area
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCenter, detectionBoxSize, transform.eulerAngles.z, detectionLayer);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                HandleGameOver();
                break; // Exit the loop if a player is found
            }
        }

        // For debugging: Draw the box in the Scene view
        DrawBox(boxCenter, detectionBoxSize, transform.eulerAngles.z);
    }

    private void HandleGameOver()
    {
        // Activate the losing panel
         StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        // Activate the cutscene
        Debug.Log("GameOverSequence started");

    CutScene.SetActive(true);

    yield return new WaitForSeconds(1);

    Debug.Log("Deactivating CutScene");
    CutScene.SetActive(false);
        LosingPanel.SetActive(true);

        // Wait for 2 seconds before stopping the game
       
        StopGame();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        // If you have additional logic to fully end the game, like going back to the main menu,
        // you can add it here.
    }

    

    // Helper method to draw the box in the Scene view for debugging
    void DrawBox(Vector3 center, Vector2 size, float angle)
    {
        var orientation = Quaternion.Euler(0, 0, angle);
        // Calculate the positions of the box's corners
        Vector3[] corners = new Vector3[4];
        corners[0] = center + orientation * new Vector3(-size.x / 2, -size.y / 2, 0);
        corners[1] = center + orientation * new Vector3(size.x / 2, -size.y / 2, 0);
        corners[2] = center + orientation * new Vector3(size.x / 2, size.y / 2, 0);
        corners[3] = center + orientation * new Vector3(-size.x / 2, size.y / 2, 0);

        Debug.DrawLine(corners[0], corners[1], Color.red);
        Debug.DrawLine(corners[1], corners[2], Color.red);
        Debug.DrawLine(corners[2], corners[3], Color.red);
        Debug.DrawLine(corners[3], corners[0], Color.red);
    }
}

