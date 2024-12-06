using UnityEngine;

public class IdleState : AbstractState
{
    [SerializeField] private Animator animator;

    private readonly int IdleStateHash = Animator.StringToHash("Idle");

    public override void StartState()
    {
        base.StartState();
    }

    private void Update()
    {
        animator.CrossFade(IdleStateHash, 0f);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
