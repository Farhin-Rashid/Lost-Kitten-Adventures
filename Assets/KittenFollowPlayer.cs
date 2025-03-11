using UnityEngine;

public class KittenFollowPlayer : MonoBehaviour
{
    public Transform player;       // Assign the Player object
    public float followSpeed = 2f; // Speed at which the kitten moves
    public float jumpForce = 5f;   // Jump strength
    public float stopDistance = 1.5f; // How close the kitten should be before stopping
    public LayerMask groundLayer;  // Assign in Unity for ground detection

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded(); // Check if the kitten is on the ground

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            MoveTowardsPlayer();
        }

        if (ShouldJump())
        {
            Jump();
        }
    }

    void MoveTowardsPlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direction * followSpeed, rb.linearVelocity.y);
    }

    bool ShouldJump()
    {
        // Check if the player is higher and if the kitten is grounded
        return isGrounded && player.position.y > transform.position.y + 0.5f;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        isGrounded = hit.collider != null;
    }
}