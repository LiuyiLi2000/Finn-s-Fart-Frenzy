using UnityEngine;

public class PlayerShakeOnIdle : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float idleTimeToShake = 4f;
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.2f;
    public float spaceKeyHoldTime = 0.8f; // Time to hold space key to stop shaking

    private float idleTimer = 0f;
    private bool isShaking = false;
    private Vector3 originalPosition;
    private float shakeTimer = 0f;
    private float spaceKeyTimer = 0f; // Timer for space key hold

    void Update()
    {
        // Check if space key is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            spaceKeyTimer += Time.deltaTime;
            if (spaceKeyTimer >= spaceKeyHoldTime)
            {
                idleTimer = 0f; // Reset idle timer
                if (isShaking)
                {
                    StopShaking();
                }
                return; // Skip further checks if space key is held long enough
            }
        }
        else
        {
            spaceKeyTimer = 0f; // Reset space key timer if not pressed
        }

        // Check if player is moving
        if (playerRigidbody.velocity.magnitude > 0.01f)
        {
            idleTimer = 0f;
            if (isShaking)
            {
                StopShaking();
            }
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTimeToShake && !isShaking)
            {
                StartShaking();
            }

            if (isShaking)
            {
                ShakePlayer();
            }
        }
    }

    private void StartShaking()
    {
        originalPosition = transform.position;
        isShaking = true;
        shakeTimer = 0f;
    }

    private void ShakePlayer()
    {
        shakeTimer += Time.deltaTime;
        if (shakeTimer > shakeDuration)
        {
            StopShaking();
            return;
        }

        float shakeFactor = Mathf.Sin(Time.time * Mathf.PI * 4) * shakeAmount;
        transform.position = originalPosition + new Vector3(shakeFactor, 0, 0);
    }

    private void StopShaking()
    {
        isShaking = false;
        transform.position = originalPosition; // Reset position to the original
    }
}


