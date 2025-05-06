using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var playerScript = collision.collider.GetComponent<PlayerMovement>();

            if (playerScript != null && playerScript.hasKey)
            {
                Destroy(gameObject);
            }
        }
    }
}
