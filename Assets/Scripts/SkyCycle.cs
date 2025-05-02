using UnityEngine;

public class SkyCycle : MonoBehaviour
{
    public Sprite[] skySprites;           // Assign Sunrise, Day, Sunset, Night in order
    public float switchInterval = 20f;    // Time between changes (adjust as needed)

    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = skySprites[currentIndex];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % skySprites.Length;
            spriteRenderer.sprite = skySprites[currentIndex];
        }
    }
}
