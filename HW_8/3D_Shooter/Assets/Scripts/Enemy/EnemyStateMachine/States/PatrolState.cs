using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AbstractState
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private float patrolRadius;

    private readonly int PatrolStateHash = Animator.StringToHash("Patrol");

    public override void StartState()
    {
        base.StartState();
        PatrolRandomPoint();
    }

    private void Update()
    {
        animator.CrossFade(PatrolStateHash, 0f);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void PatrolRandomPoint()
    {
        agent.SetDestination(GetRandomPointOnNavMeshSurface(patrolRadius));
    }

    private Vector3 GetRandomPointOnNavMeshSurface(float radius)
    {
        // генерация случайной точки в радиусе
        var randomPoint = Random.insideUnitSphere * radius;

        // попадает ли точка на навигационную сетку NavMesh
        if (NavMesh.SamplePosition(randomPoint, out var hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);  // рисует сферу вокруг персонажа
    }
}
