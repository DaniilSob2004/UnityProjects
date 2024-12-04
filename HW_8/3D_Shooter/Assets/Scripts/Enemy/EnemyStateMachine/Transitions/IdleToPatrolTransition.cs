using UnityEngine;

public class IdleToPatrolTransition : AbstractTransition
{
    [SerializeField] private float transitionDelay;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > transitionDelay)
        {
            ShouldTransition = true;
            timer = 0f;
        }
    }
}
