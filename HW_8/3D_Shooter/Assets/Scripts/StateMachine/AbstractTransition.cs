using UnityEngine;

public class AbstractTransition : MonoBehaviour
{
    [SerializeField] private AbstractState stateToTransition;

    public AbstractState StateToTransition {
        get => stateToTransition;
        set { stateToTransition = value; }
    }
    public bool ShouldTransition { get; set; }

    private void OnEnable()
    {
        ShouldTransition = false;
    }
}
