using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class leak : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer playerSpriteRenderer;
    public VideoPlayer videoPlayer;
    public float loopDelay = 3f;


    private Vector3 offset;

    private bool isWaiting = false;

    private void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (!isWaiting)
        {
            StartCoroutine(WaitAndPlayAgain(loopDelay));
        }
    }

    private IEnumerator WaitAndPlayAgain(float delay)
    {
        isWaiting = true;
        yield return new WaitForSeconds(delay);
        videoPlayer.Play();
        isWaiting = false;
    }


    private void Update()
    {
        
    
        // Check if the boss is active
      

       
    
        // Update position based on player's sprite orientation
        if (playerSpriteRenderer.sprite.name.Contains("back")) // Assuming sprite names contain orientation
        {
            offset = new Vector3(0, -1, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (playerSpriteRenderer.sprite.name.Contains("front"))
        {
            offset = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (playerSpriteRenderer.sprite.name.Contains("left"))
        {
            offset = new Vector3(1, -1, 0);
        }
        else if (playerSpriteRenderer.sprite.name.Contains("right"))
        {
            offset = new Vector3(-1, -1, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        transform.position = player.position + offset;
    }
     private void OnDestroy()
    {
        // Unsubscribe from event when the object is destroyed
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
