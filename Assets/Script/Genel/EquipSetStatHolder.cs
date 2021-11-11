using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class SetEquipGrup
{
    public Skill_Item skill_Item;
    public List<StatDurum> mySetStats = new List<StatDurum>();
}
[System.Serializable]
public class SetStats
{
    public List<SetEquipGrup> myDressSetStats = new List<SetEquipGrup>();
    public List<SetEquipGrup> myWeaponSetStats = new List<SetEquipGrup>();
    public List<SetEquipGrup> myAccessuarsSetStats = new List<SetEquipGrup>();
    public List<SetEquipGrup> myCompleteSetStats = new List<SetEquipGrup>();
}
public class EquipSetStatHolder : MonoBehaviour
{
    public List<SetStats> allSetStats = new List<SetStats>();
    public SetStats ReturnSetStats(int set)
    {
        return allSetStats[set];
    }
}