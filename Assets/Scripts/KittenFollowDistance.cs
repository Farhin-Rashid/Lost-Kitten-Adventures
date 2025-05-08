using UnityEngine;
using Pathfinding;

public class KittenFollowDistance : MonoBehaviour
{
    public Transform witch;
    public float followDistance = 2f; // Adjust as needed (2 units = ~2 tiles)

    private AIPath aiPath;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
    }

    void Update()
    {
        if (witch == null || aiPath == null) return;

        float distance = Vector2.Distance(transform.position, witch.position);

        if (distance < followDistance)
        {
            aiPath.canMove = false; // Stop if too close
        }
        else
        {
            aiPath.canMove = true; // Resume following
        }
    }
}
