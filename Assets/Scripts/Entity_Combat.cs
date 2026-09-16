using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    public float damage = 10;

    [Header("Target detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    public void PerformAttack()
    {
        foreach(var target in GetDetectedColliers())
        {
            Entity_Heath targetHeath = target.GetComponent<Entity_Heath>();
            targetHeath?.TakeDamage(damage);
        }
    }

    private Collider2D[] GetDetectedColliers()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
