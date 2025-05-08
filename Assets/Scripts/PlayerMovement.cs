using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float horizontal;
    private float speed = 15f;
    private float jumpingPower = 25f;
    private bool isFacingRight;
    public bool isOnGround;
    private Vector3 startingPoint;
    public bool hasKey;
    public bool hasYarn;

    // Initialize
    private void Start()
    {
        isFacingRight = true;
        isOnGround = false;
        startingPoint = this.transform.position;
        hasKey = false;
        hasYarn = false;
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        // Jump
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpingPower);
        }

        // Turn to face movement direction
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset to start
        if (collision.gameObject.CompareTag("Boundary"))
        {
            this.transform.position = startingPoint;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } 
        rb.linearVelocity = new Vector2(rb.linearVelocityX, -9.8f);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false; 
        }
    }
}
