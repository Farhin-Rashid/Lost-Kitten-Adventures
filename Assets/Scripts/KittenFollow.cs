using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class KittenFollow : MonoBehaviour
{
    public Transform witchTarget;
    private NavMeshAgent agent;

    [SerializeField] private float followDistance = 15f;
    [SerializeField] private Vector3 followOffset = new Vector3(-10f, 0, 0); // Left side offset

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name + "!");
        }
    }

    void Update()
    {
        if (witchTarget != null)
        {
            float distance = Vector2.Distance(transform.position, witchTarget.position);

            if (distance > 15f) // Adjust this number for space between kitten and witch
            {
                agent.SetDestination(witchTarget.position);
            }
            else
            {
                agent.ResetPath(); // Stop moving when too close
            }
        }
    }

}
