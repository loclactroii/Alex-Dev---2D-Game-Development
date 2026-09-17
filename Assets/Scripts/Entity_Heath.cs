using System;
using UnityEngine;

public class Entity_Heath : MonoBehaviour
{
    private Entity_VFX entityVfx;
    private Entity entity;

    protected float currentHp;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected bool isDead;

    [Header("On Damage Knockback")]
    [SerializeField] private Vector2 knockbackPower = new Vector2(1.5f, 2.5f);
    [SerializeField] private Vector2 heavyKnockbackPower = new Vector2(7f, 7f);
    [SerializeField] private float knockbackDuration = .2f;
    [SerializeField] private float heavyKnockbackDuration = .5f;

    [Header("On Heavy Damage")]
    [SerializeField] private float heavyDamageThreshold = .3f;

    private void Awake()
    {
        entityVfx = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();

        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if (isDead)
            return;

        Vector2 knockback = CalculateKnockback(damage, damageDealer);
        float duration = CalculateDuration(damage);

        entity?.ReceiveKnockback(knockback, duration);
        entityVfx?.PlayOnDamageVfx();
        ReduceHp(damage);
    }

    protected void ReduceHp(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
            Die();
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Entity died!");
    }

    private Vector2 CalculateKnockback(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;
        Vector2 knockback = isHeavyDamage(damage) ? heavyKnockbackPower: knockbackPower;
        knockback.x = knockback.x * direction;
        return knockback;
    }


    private float CalculateDuration(float damage) => isHeavyDamage(damage) ? heavyKnockbackDuration : knockbackDuration;
    private bool isHeavyDamage(float damage) => damage / maxHp > heavyDamageThreshold; 
}
