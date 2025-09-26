using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour
{
    public float redirectDelay = 0.5f; // Delay before the fart is moved to the side
    public float moveDuration = 0.5f;  // Duration it takes for the fart to move to the side

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fart"))
        {
            StartCoroutine(MoveFartSmoothly(other.transform));
        }
    }

    private IEnumerator MoveFartSmoothly(Transform fartTransform)
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(redirectDelay);

        // Calculate the new position for the fart
        Vector3 startPosition = fartTransform.position;
        Vector3 endPosition = startPosition + new Vector3(22, 0, 0);
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        while (Vector3.Distance(fartTransform.position, endPosition) > 0.05f)
        {
            float distanceCovered = (Time.time - startTime) * moveDuration;
            float fractionOfJourney = distanceCovered / journeyLength;

            fartTransform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            yield return null;
        }

        // Ensure the fart is at the exact end position
        fartTransform.position = endPosition;
    }
}





