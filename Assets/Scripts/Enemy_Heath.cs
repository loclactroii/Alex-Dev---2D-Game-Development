using UnityEngine;

public class Enemy_Heath : Entity_Heath
{
    private Enemy enemy => GetComponent<Enemy>();

    public override void TakeDamage(float damage, Transform dameDealer)
    {
        if (dameDealer.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(dameDealer);
        base.TakeDamage(damage, dameDealer);
    }
}
