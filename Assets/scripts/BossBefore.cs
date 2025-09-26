using UnityEngine;

public class BossBefore : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.Space;
    public GameObject Boss;
    public GameObject Boss1;
    public GameObject Boss2;
    
    private float keyHoldTime = 0f; // Time the key is held down
    private const float RequiredHoldTime = 0.8f; // Time required to activate the boss manually

    private float autoActivateTimer = 0f; // Timer for the automatic boss activation
    public float AutoActivateTime = 45f; // Made this a non-constant variable so it can be changed

    private void Update()
    {
        if (Input.GetKey(inputKey))
        {
            keyHoldTime += Time.deltaTime;

            if (keyHoldTime >= RequiredHoldTime)
            {
                ActivateBoss();
                keyHoldTime = 0f;
            }
        }
        else
        {
            keyHoldTime = 0f;
        }

        // Logic for automatic boss activation after a set time
        autoActivateTimer += Time.deltaTime;
        if (autoActivateTimer >= AutoActivateTime)
        {
            ActivateBoss();
            autoActivateTimer = 0f; // Reset the timer, or disable the script if you want this to occur only once.
        }
    }

    void ActivateBoss()
    {
        // Set Boss1's position and rotation to match Boss's current position and rotation
        Boss.transform.position = Boss1.transform.position;
        Boss.transform.rotation = Boss1.transform.rotation;

        // Activate Boss1 and deactivate Boss
        Boss.SetActive(true);
        Boss1.SetActive(false);
        Boss2.SetActive(true);
    }

    // Public method to update the AutoActivateTime
    public void UpdateAutoActivateTime(float newTime)
    {
        AutoActivateTime = newTime;
        autoActivateTimer = 0f; // Also reset the countdown timer
    }
}



