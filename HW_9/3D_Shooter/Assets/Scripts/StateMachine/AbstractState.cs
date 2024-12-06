using UnityEngine;

public class AbstractState : MonoBehaviour
{
    [SerializeField] private AbstractTransition[] transitions;

    public virtual void StartState()
    {
        if (!enabled)
        {
            enabled = true;

            // при старте включаем все транзишины
            foreach (var transition in transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public virtual void ExitState()
    {
        if (enabled)
        {
            enabled = false;

            // при выходе выключаем все транзишины
            foreach (var transition in transitions)
            {
                transition.enabled = false;
            }
        }
    }

    public AbstractState GetNextState()
    {
        foreach (var transition in transitions)
        {
            if (transition.ShouldTransition)
            {
                return transition.StateToTransition;
            }
        }
        return null;
    }
}
