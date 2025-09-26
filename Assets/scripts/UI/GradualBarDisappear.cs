using UnityEngine;
using UnityEngine.UI;

public class GradualBarDisappear : MonoBehaviour
{
    public Image barImage; // Assign the UI Image component here
    public float duration = 44f; // Duration over which the bar will disappear

    private float timeElapsed;

    private void Update()
    {
        if (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float fill = 1 - (timeElapsed / duration);
            barImage.fillAmount = fill;
        }
    }
}