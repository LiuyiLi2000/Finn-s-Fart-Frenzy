using UnityEngine;

public class SpriteVideoPlayer : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Play()
    {
        animator.Play("YourAnimationName", -1, 0f); // Replace with your animation name
    }

    public void Stop()
    {
        animator.StopPlayback();
    }

    // Add more methods as needed for pause, resume, etc.
}
