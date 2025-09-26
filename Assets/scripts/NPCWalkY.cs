using UnityEngine;
using System.Collections;

public class NPCWalkY : MonoBehaviour
{
    public float startY = 3.9f;
    public float endY = -2.2f;
    public float speed = 1.0f; // Speed of movement

    private void Start()
    {
        StartCoroutine(MoveBackAndForth());
    }

    private IEnumerator MoveBackAndForth()
    {
        while (true) // Infinite loop to keep the NPC moving
        {
            // Move to endY
            yield return MoveToPosition(endY);

            // Move to startY
            yield return MoveToPosition(startY);
        }
    }

    private IEnumerator MoveToPosition(float targetY)
    {
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            float newY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null; // Wait for the next frame
        }
    }
}

