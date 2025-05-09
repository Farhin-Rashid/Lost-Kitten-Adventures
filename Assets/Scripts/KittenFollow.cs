using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //Ensures the agent component exists
public class KittenFollow : MonoBehaviour
{
    public Transform witchTarget;
    private NavMeshAgent agent;

    [SerializeField] private float followDistance = 15f;
    [SerializeField] private Vector3 followOffset = new Vector3(-10f, 0, 0); // Left side offset

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); //Get the NavMeshAgent component attached to the kitten

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name + "!");
        }
    }

    void Update()
    {
        //check if a target has been assigned
        if (witchTarget != null)
        {
            float distance = Vector2.Distance(transform.position, witchTarget.position);

            if (distance > 15f) // Adjust this number for space between kitten and witch
            {
                agent.SetDestination(witchTarget.position); //Tell the agent to move towards the target's current position
            }
            else
            {
                agent.ResetPath(); // Stop moving when too close
            }
        }
    }

}
