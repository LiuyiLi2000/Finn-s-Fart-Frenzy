using UnityEngine;
using System.Collections;

public class BossHeadSpin1 : MonoBehaviour
{
    public float rotationDuration = 1f;  // Duration for each rotation

    private void Start()
    {
        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        while (true)
        {
            // Initial wait of 3 seconds
            yield return new WaitForSeconds(2f);

            // Rotate left 60 degrees and wait 2 seconds
            yield return RotateOverTime(-30f);
            yield return new WaitForSeconds(4f);

            // Rotate right 60 degrees (relative to current rotation) and wait 2 seconds
            yield return RotateOverTime(60f);
            yield return new WaitForSeconds(2f);

            // Rotate back to original position and wait 1 second
            yield return RotateOverTime(-30f);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator RotateOverTime(float amount)
    {
        float elapsed = 0f;
        float startingRotation = transform.eulerAngles.z;
        float targetRotation = startingRotation + amount;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / rotationDuration; // Goes from 0 to 1
            float currentRotation = Mathf.Lerp(startingRotation, targetRotation, normalizedTime);
            transform.eulerAngles = new Vector3(0, 0, currentRotation);
            yield return null;
        }

        // Correct any minor discrepancies in the rotation
        transform.eulerAngles = new Vector3(0, 0, targetRotation);
    }
}
