using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject areaIndicator; // Assign your area indicator GameObject in the inspector

    void Start()
    {
        // Make sure the area is not visible at start
        if (areaIndicator != null)
            areaIndicator.SetActive(false);
        else
            Debug.LogError("Area indicator not assigned in the inspector");
    }

    void Update()
    {
        // Check if the space bar is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (areaIndicator != null)
                areaIndicator.SetActive(true);
            else
                Debug.LogError("Area indicator reference is missing");
        }

        // Check if the space bar has been released
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            if (areaIndicator != null)
                areaIndicator.SetActive(false);
            else
                Debug.LogError("Area indicator reference is missing");
        }
        
    }
}


