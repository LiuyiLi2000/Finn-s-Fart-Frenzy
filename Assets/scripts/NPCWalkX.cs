using UnityEngine;
using System.Collections;

public class NPCXMovement : MonoBehaviour
{
    public float startX = 8.3f;
    public float endX = 1.8f;
    public float speed = 1.0f; // Speed of movement

    private void Start()
    {
        StartCoroutine(MoveBackAndForthX());
    }

    private IEnumerator MoveBackAndForthX()
    {
        while (true) // Infinite loop to keep the NPC moving
        {
            // Move to endX
            yield return MoveToPositionX(endX);

            // Move to startX
            yield return MoveToPositionX(startX);
        }
    }

    private IEnumerator MoveToPositionX(float targetX)
    {
        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            yield return null; // Wait for the next frame
        }
    }
}



