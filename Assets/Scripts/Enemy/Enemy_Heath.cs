using UnityEngine;

public class Enemy_Heath : Entity_Heath
{
    private Enemy enemy => GetComponent<Enemy>();

    public override bool TakeDamage(float damage, Transform dameDealer)
    {
        bool wasHit = base.TakeDamage(damage, dameDealer);
        if (wasHit == false)
            return false;

        if (dameDealer.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(dameDealer);

        return true;
    }
}
