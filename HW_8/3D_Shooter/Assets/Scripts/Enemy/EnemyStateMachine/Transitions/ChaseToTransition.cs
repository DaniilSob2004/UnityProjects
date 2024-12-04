using UnityEngine;

public class ChaseToTransition : AbstractTransition
{
    [SerializeField] private Player.Player player;
    [SerializeField] private Enemy.Enemy enemy;
    [SerializeField] private float chaseRadius;

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) >= chaseRadius)
        {
            ShouldTransition = true;
        }
    }
}
