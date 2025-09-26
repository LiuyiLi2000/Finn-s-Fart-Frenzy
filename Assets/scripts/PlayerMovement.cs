using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    // Enumeration for the direction the player is facing.
    public enum PlayerDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    // Public property to expose the current direction.
    public PlayerDirection currentDirection { get; private set; }

    // Sprites for each direction
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentDirection = PlayerDirection.Right; // Default direction
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.velocity = moveDirection * speed;

        // Change the sprite and direction based on movement
        if (horizontal > 0) 
        {
            sr.sprite = rightSprite;
            currentDirection = PlayerDirection.Right;
        }
        else if (horizontal < 0) 
        {
            sr.sprite = leftSprite;
            currentDirection = PlayerDirection.Left;
        }
        else if (vertical > 0) 
        {
            sr.sprite = upSprite;
            currentDirection = PlayerDirection.Up;
        }
        else if (vertical < 0) 
        {
            sr.sprite = downSprite;
            currentDirection = PlayerDirection.Down;
        }
    }
}

