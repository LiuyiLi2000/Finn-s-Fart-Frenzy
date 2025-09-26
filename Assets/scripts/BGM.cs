using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3; // Assign the panel GameObject in the Inspector
    private AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        if (backgroundMusic == null)
        {
            Debug.LogError("AudioSource component missing from this GameObject");
        }
    }

    void Update()
    {
        if (panel.activeSelf && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        if (panel1.activeSelf && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        if (panel2.activeSelf && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        if (panel3.activeSelf && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
}

