using UnityEngine;

public class Enemy_Heath : Entity_Heath
{
    private Enemy enemy => GetComponent<Enemy>();

    public override bool TakeDamage(float damage, float elementalDamage, Transform dameDealer)
    {
        bool wasHit = base.TakeDamage(damage, elementalDamage, dameDealer);
        if (wasHit == false)
            return false;

        if (dameDealer.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(dameDealer);

        return true;
    }
}
