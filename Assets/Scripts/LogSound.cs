using UnityEngine;

public class LogSound : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public float velocityThreshold = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Only play sound if moving horizontally and not already playing
        if (Mathf.Abs(rb.linearVelocity.x) > velocityThreshold)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }
}
