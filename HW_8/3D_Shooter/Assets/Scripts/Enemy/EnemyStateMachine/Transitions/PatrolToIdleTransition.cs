using UnityEngine;
using UnityEngine.AI;

public class PatrolToIdleTransition : AbstractTransition
{
    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        if (agent.pathPending == false && agent.remainingDistance <= agent.stoppingDistance)
        {
            ShouldTransition = true;
        }
    }
}
