using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 10f); // 10x volume because it's so quiet

            Destroy(gameObject);
        }
    }
}
