using UnityEngine;
using UnityEngine.UI;

public class KeyCollider : MonoBehaviour
{
    public Image keyImage;
    public AudioClip pickupSound;

    void Start()
    {
        keyImage.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerScript = other.GetComponent<PlayerMovement>();
            if(playerScript != null)
            {
                playerScript.hasKey = true;
            }
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 10f);
            Destroy(gameObject);
            keyImage.enabled = true;
        }
    }
}
