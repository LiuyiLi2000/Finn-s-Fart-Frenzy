using UnityEngine;
using UnityEngine;

public class AreaDi: MonoBehaviour
{
    public GameObject areaIndicator;
    public PlayerMovement playerMovement; // Assume this is a reference to your PlayerMovement script

    void Update()
    {
        MoveAndRotateAreaIndicator();
    }

    private void MoveAndRotateAreaIndicator()
    {
        if (areaIndicator != null && playerMovement != null)
        {
            Vector3 offset = Vector3.zero;
            float rotationZ = 0f;

            // Adjust offset and rotation based on player direction
            switch (playerMovement.currentDirection)
            {
                case PlayerMovement.PlayerDirection.Up:
                    offset.y -= 3; 
                    rotationZ = -90;
                    break;
                case PlayerMovement.PlayerDirection.Down:
                    offset.y += 4; 
                    rotationZ = 90;
                    break;
                case PlayerMovement.PlayerDirection.Left:
                    offset.x += 3; 
                    offset.y -= 1;
                    // No rotation needed since this is the default orientation
                    break;
                case PlayerMovement.PlayerDirection.Right:
                    offset.x -= 3; 
                    offset.y -= 1;
                    rotationZ = 180;
                    break;
            }

            // Update areaIndicator position and rotation
            areaIndicator.transform.position = playerMovement.transform.position + offset;
            areaIndicator.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
    public void DoubleAreaSize()
    {
        if (areaIndicator != null)
        {
            areaIndicator.transform.localScale *= 2; // Double the scale
        }
    }
}
