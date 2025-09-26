using UnityEngine;
using UnityEngine.UI;

public class TimerBarUI : MonoBehaviour
{
    public float totalTime = 45.0f;
    public Sprite[] timerSprites;  // Your sequence of timer sprites

    private Image timerImage;
    private float timePerFrame;

    private void Start()
    {
        timerImage = GetComponent<Image>();
        timePerFrame = totalTime / timerSprites.Length;
    }

    private void Update()
    {
        totalTime -= Time.deltaTime;

        int spriteIndex = Mathf.Clamp((int)(totalTime / timePerFrame), 0, timerSprites.Length - 1);
        timerImage.sprite = timerSprites[spriteIndex];

        if (totalTime <= 0)
        {
            // Do something when time is up, e.g., show LosingPanel
        }
    }
}

