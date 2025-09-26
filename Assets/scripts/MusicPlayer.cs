using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MusicPlayer : MonoBehaviour
{
    public string sceneToStopMusic; // Name of the scene where music should stop
    private AudioSource audioSource;

    void Awake()
    {
        // Existing setup code...

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check the current scene name
        if (SceneManager.GetActiveScene().name == sceneToStopMusic)
        {
            // If the current scene is the scene to stop music, stop the audio
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else
        {
            // If it's any other scene, ensure the music is playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}




