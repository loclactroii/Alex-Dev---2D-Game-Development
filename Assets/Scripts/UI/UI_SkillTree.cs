using UnityEngine;

public class UI_SkillTree : MonoBehaviour
{
    public int skillPoints;
    [SerializeField] private UI_TreeConnectHandler[] parentNodes;

    public bool EnoughSkillPoints(int cost) => skillPoints >= cost;
    public void RemoveSkillPoints(int cost) => skillPoints -= cost;
    public void AddSkillPoints(int points) => skillPoints = skillPoints + points;

    private void Start()
    {
        UpdateAllConnection();
    }

    [ContextMenu("Reset Skill Tree")]
    public void RefundAllSkills()
    {
        UI_TreeNode[] skillNodes = GetComponentsInChildren<UI_TreeNode>();

        foreach (var node in skillNodes)
            node.Refund();
    }

    [ContextMenu("Update All Connections")]
    public void UpdateAllConnection()
    {
        foreach (var node in parentNodes)
        {
            node.UpdateAllConnections();
        }
    }
}
