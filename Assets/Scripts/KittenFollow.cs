using UnityEngine;
using UnityEngine.AI; // <-- Make sure to include this namespace!

[RequireComponent(typeof(NavMeshAgent))] // Ensures the agent component exists
public class KittenFollow : MonoBehaviour
{
    public Transform witchTarget; // Drag the Witch object here in the Inspector
    private NavMeshAgent agent;

    void Awake()
    {
        // Get the NavMeshAgent component attached to this kitten
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name + "!");
        }
    }

    void Update()
    {
        // Check if a target has been assigned
        if (witchTarget != null)
        {
            // Tell the agent to move towards the target's current position
            agent.SetDestination(witchTarget.position);
        }
    }
}