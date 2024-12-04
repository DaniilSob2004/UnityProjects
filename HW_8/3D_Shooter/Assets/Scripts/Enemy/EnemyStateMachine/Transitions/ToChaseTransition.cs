using UnityEngine;

public class ToChaseTransition : AbstractTransition
{
    [SerializeField] private Player.Player player;
    [SerializeField] private Enemy.Enemy enemy;
    [SerializeField] private float detectedRadius;

    private void Update()
    {
        if (Vector3.Distance(enemy.transform.position, player.transform.position) <= detectedRadius)
        {
            ShouldTransition = true;
        }
    }
}
