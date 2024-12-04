using UnityEngine;
using UnityEngine.AI;

public class ChaseState : AbstractState
{
    [SerializeField] private Player.Player player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private readonly int ChaseStateHash = Animator.StringToHash("Run");

    public override void StartState()
    {
        base.StartState();
    }

    private void Update()
    {
        animator.CrossFade(ChaseStateHash, 0f);
        agent.SetDestination(player.transform.position);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);  // рисует сферу вокруг персонажа
    }
}
