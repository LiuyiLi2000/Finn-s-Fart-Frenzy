using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    public GameObject zeroStarPanel;
    public GameObject oneStarPanel;
    public GameObject twoStarPanel;
    public GameObject threeStarPanel;

    private bool gameStarted = false;

    void Update()
    {
        if (!gameStarted) return;

        int activeCount = CountActiveObjects();

        // Update panels based on the number of active objects
        zeroStarPanel.SetActive(activeCount == 0);
        oneStarPanel.SetActive(activeCount == 1 || activeCount == 2);
        twoStarPanel.SetActive(activeCount == 3);
        threeStarPanel.SetActive(activeCount == 4);

        // Pause the game if any panel is active
        if (zeroStarPanel.activeSelf || oneStarPanel.activeSelf || 
            twoStarPanel.activeSelf || threeStarPanel.activeSelf)
        {
            Time.timeScale = 0;
        }
    }

    private int CountActiveObjects()
    {
        int activeCount = 0;

        // Increment activeCount for each active object
        if (IsObjectActive(object1)) activeCount++;
        if (IsObjectActive(object2)) activeCount++;
        if (IsObjectActive(object3)) activeCount++;
        if (IsObjectActive(object4)) activeCount++;

        return activeCount;
    }

    private bool IsObjectActive(GameObject obj)
    {
        return obj != null && obj.activeSelf;
    }

    // Call this method to indicate that the game has started
    public void StartGame()
    {
        gameStarted = true;
    }
}










