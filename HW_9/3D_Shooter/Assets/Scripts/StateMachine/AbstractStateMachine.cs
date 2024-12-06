using UnityEngine;

public class AbstractStateMachine : MonoBehaviour
{
    [SerializeField] protected AbstractState startState;

    private AbstractState currentState;

    private void Awake()
    {
        currentState = startState;
    }

    private void Start()
    {
        currentState.StartState();
    }

    private void Update()
    {
        if (currentState == null) { return; }

        var nextState = currentState.GetNextState();
        if (nextState != null)
        {
            Transition(nextState);
        }
    }

    private void Transition(AbstractState nextState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = nextState;
        currentState.StartState();
    }
}
