using UnityEngine;

[System.Serializable]
public class Skill_Buffer : Skill
{
    [Header("Skill Buffer Atamalarư")]
    public string buffName;
    public int buffAmount;
    public bool isPercent;
}