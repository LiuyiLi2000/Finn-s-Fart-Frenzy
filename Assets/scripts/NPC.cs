using UnityEngine;

public class NPC: MonoBehaviour
{
    public float moveSpeed = 2f;
    public float distance = 5f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + distance, startPos.y, startPos.z);
    }

    void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            if (transform.position == endPos)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (transform.position == startPos)
                movingToEnd = true;
        }
    }
}

