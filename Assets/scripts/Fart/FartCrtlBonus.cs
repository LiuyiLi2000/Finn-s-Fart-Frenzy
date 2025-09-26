using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartCtrlBonus : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.Space;
    public GameObject bombPrefab;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    private float keyHoldTime = 0f; 
    private const float RequiredHoldTime = 0.8f; 

    private float stillnessTimer = 0f;
    private const float StillnessTime = 6f;

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        // Check for player movement
        float movement = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
        if (movement > 0.01f) // Threshold for movement detection
        {
            stillnessTimer = 0f; // Reset the stillness timer if there's movement
        }
        else
        {
            stillnessTimer += Time.deltaTime;
            if (stillnessTimer >= StillnessTime)
            {
                TriggerFart(); // Trigger the fart if the player has been still for 3 seconds
                stillnessTimer = 0f;
            }
        }

        if (Input.GetKey(inputKey))
        {
            keyHoldTime += Time.deltaTime; 
            if (keyHoldTime >= RequiredHoldTime)
            {
                TriggerFart();
                keyHoldTime = 0f; 
            }
        }
        else
        {
            keyHoldTime = 0f; 
        }

        // autoFartTimer functionality removed
    }

    void TriggerFart()
    {
        if (bombsRemaining > 0)
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        float rotationZ = 0;

        switch (playerMovement.currentDirection)
        {
            case PlayerMovement.PlayerDirection.Up:
                position.y -= 3; 
                rotationZ = -90;
                break;
            case PlayerMovement.PlayerDirection.Down:
                position.y += 4; 
                rotationZ = 90; 
                break;
            case PlayerMovement.PlayerDirection.Left:
                position.x += 3; 
                position.y -= 1;
                break;
            case PlayerMovement.PlayerDirection.Right:
                position.x -= 3; 
                position.y -= 1;
                rotationZ = 180; 
                break;
        }

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.Euler(0, 0, rotationZ));

        yield return new WaitForSeconds(bombFuseTime);
        Destroy(bomb);
    }
}
