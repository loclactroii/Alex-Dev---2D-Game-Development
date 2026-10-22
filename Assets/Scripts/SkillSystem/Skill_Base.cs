using UnityEngine;

public class Skill_Base : MonoBehaviour
{
    [Header("General details")]
    [SerializeField] private float cooldown;
    private float lastTimeUsed;

    public virtual void Awake()
    {
        lastTimeUsed = lastTimeUsed - cooldown;
    }

    public bool CanUseSkill()
    {
        if (OnCoolDown())
        {
            Debug.LogWarning("On Cooldown");
            return false;
        }

        return true;
    }

    private bool OnCoolDown() => Time.time < lastTimeUsed + cooldown;
    public void SetSkillOnCooldown() => lastTimeUsed = Time.time;
    public void ResetCoolDownBy(float cooldownReduction) => lastTimeUsed = lastTimeUsed + cooldownReduction;
    public void ResetCooldown() => lastTimeUsed = Time.time;
}
