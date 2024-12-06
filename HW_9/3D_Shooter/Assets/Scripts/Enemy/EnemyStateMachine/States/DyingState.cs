using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DyingState : AbstractState
{
    [SerializeField] private Enemy.Enemy enemy;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private readonly int DyingStateHash = Animator.StringToHash("Dying");
    private bool isPlayAnimate = false;

    public override void StartState()
    {
        base.StartState();
        OnDying();
    }

    private void Update()
    {
        if (!isPlayAnimate)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void OnDying()
    {
        isPlayAnimate = true;
        animator.CrossFade(DyingStateHash, 0f);
        agent.enabled = false;
        StartCoroutine(WaitDyingAnimation());
    }

    private IEnumerator WaitDyingAnimation()
    {
        yield return null;  // ждем, пока новая анимация начнет воспроизводиться
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isPlayAnimate = false;
    }
}
