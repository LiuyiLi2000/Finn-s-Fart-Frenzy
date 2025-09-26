using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject Boss;     // Assign Boss GameObject in the inspector
    public GameObject Boss1;
        // Assign Boss1 GameObject in the inspector
    public float stillnessDuration = 6f; // Time in seconds the player needs to be still

    private float stillnessTimer = 0f;

    void Update()
    {
        // Check if the player is moving
        float movement = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
        if (movement > 0.01f) // Adjust the threshold according to your needs
        {
            stillnessTimer = 0f; // Reset the timer if there's movement
        }
        else
        {
            stillnessTimer += Time.deltaTime; // Increment the timer if the player is still
            if (stillnessTimer >= stillnessDuration)
            {
                ActivateBoss();
                stillnessTimer = 0f; // Reset the timer after activating the boss
            }
        }
    }

    private void ActivateBoss()
    {    
        Boss.transform.rotation = Boss1.transform.rotation;
        Boss.SetActive(true);
        Boss1.SetActive(false);
        Debug.Log("Boss activated and Boss1 deactivated due to player stillness.");
    }
}

