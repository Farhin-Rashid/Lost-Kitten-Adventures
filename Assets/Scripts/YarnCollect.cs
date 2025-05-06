using UnityEngine;
using UnityEngine.UI;

public class YarnCollect : MonoBehaviour
{
    public Image yarnImage;

    void Start()
    {
        yarnImage.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerScript = other.GetComponent<PlayerMovement>();
            if(playerScript != null)
            {
                playerScript.hasYarn = true;
            }
            Destroy(gameObject);
            yarnImage.enabled = true;
        }
    }
}
