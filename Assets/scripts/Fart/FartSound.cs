using UnityEngine;

public class FartSound: MonoBehaviour
{
    public AudioClip soundClip; // Assign the sound clip in the inspector
    private AudioSource audioSource;
    private float holdTime = 0.8f; // Duration for long press
    private float timer;
    private bool isPressed;

   void Start()
{
    // Initialize AudioSource
    audioSource = GetComponent<AudioSource>();
    if (audioSource == null)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    audioSource.clip = soundClip;
    audioSource.loop = false; // Ensure the sound doesn't loop
}

    void Update()
    {
        // Check if the space key is being held down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressed = true;
            timer = 0; // Reset the timer
        }

        if (isPressed)
        {
            timer += Time.deltaTime; // Increment the timer
        }

        // Check if the space key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressed = false;
            if (timer >= holdTime)
            {
                // Play the sound if the key was held for at least 0.8 seconds
                audioSource.Play();
            }
        }
    }
}
