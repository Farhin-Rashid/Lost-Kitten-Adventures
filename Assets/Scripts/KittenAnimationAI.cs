using UnityEngine;
using Pathfinding; // Required for AIPath

public class KittenAnimationAI : MonoBehaviour
{
    public Animator animator;
    private AIPath aiPath;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
    }

    void Update()
    {
        animator.SetFloat("Speed", aiPath.desiredVelocity.magnitude);
    }
}
