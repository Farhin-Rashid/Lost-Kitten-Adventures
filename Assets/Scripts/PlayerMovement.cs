using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public float jumpSpeed = 7f;
    public float movementSpeed = 5f;
    private bool isOnGround = false;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        float horizontalDirection = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalDirection = 1f;
            player.linearVelocity = new Vector2(horizontalDirection * movementSpeed, player.linearVelocityY);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalDirection = -1f;
            player.linearVelocity = new Vector2(horizontalDirection * movementSpeed, player.linearVelocityY);
        }

        // Handle jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
        {
            player.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
