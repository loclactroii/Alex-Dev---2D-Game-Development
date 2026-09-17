using UnityEngine;

public class Enemy_Heath : Entity_Heath
{
    private Enemy enemy => GetComponent<Enemy>();

    public override void TakeDamage(float damage, Transform dameDealer)
    {
        base.TakeDamage(damage, dameDealer);
        if (isDead)
            return;

        if (dameDealer.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(dameDealer);
    }
}
