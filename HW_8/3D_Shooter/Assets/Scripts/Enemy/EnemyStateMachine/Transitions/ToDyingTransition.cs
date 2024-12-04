using UnityEngine;

public class ToDyingTransition : AbstractTransition
{
    [SerializeField] private float dyingTime;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dyingTime)
        {
            ShouldTransition = true;
        }
    }
}
