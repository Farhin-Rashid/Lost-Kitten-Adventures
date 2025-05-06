using UnityEngine;

public class KittenSounds : MonoBehaviour
{
    public Transform witch;
    public float meowDistance = 10f;
    public float purrDistance = 3f;

    public AudioClip meowClip;
    public AudioClip purrClip;

    private AudioSource audioSource;
    private float meowTimer;
    public float meowInterval = 2f;

    private bool isPurring = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, witch.position);

        // Handle meowing when too far
        if (distance >= meowDistance)
        {
            meowTimer += Time.deltaTime;

            if (meowTimer >= meowInterval)
            {
                audioSource.loop = false;
                audioSource.clip = meowClip;
                audioSource.Play();
                meowTimer = 0f;
            }

            // Stop purring if it was purring
            if (isPurring)
            {
                audioSource.Stop();
                isPurring = false;
            }
        }
        // Handle purring when close
        else if (distance <= purrDistance)
        {
            if (!isPurring)
            {
                audioSource.loop = true;
                audioSource.clip = purrClip;
                audioSource.Play();
                isPurring = true;
            }
        }
        else
        {
            // In between: stop purring if active
            if (isPurring)
            {
                audioSource.Stop();
                isPurring = false;
            }

            meowTimer = 0f;
        }
    }
}
