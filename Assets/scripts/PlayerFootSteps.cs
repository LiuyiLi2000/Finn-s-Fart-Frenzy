using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip footstepClip; 
    public float walkThreshold = 0.1f; 

    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        
        if (rb.velocity.magnitude > walkThreshold && !footstepAudioSource.isPlaying)
        {
            
            footstepAudioSource.PlayOneShot(footstepClip);
        }
    }
}
