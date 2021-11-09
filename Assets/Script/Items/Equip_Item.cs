using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StatDurum
{
    public Stat stat;
    public bool isPercent;
}
[CreateAssetMenu(menuName = "Item/Equip Item")]
public class Equip_Item : Item
{
    public Body_Part bodyPart;
    public Skill_Item skill_Item;
    public bool ciftKol;
    public List<StatDurum> myStats = new List<StatDurum>();
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.equip_Manager_Player.ItemEquip(this, mySlot);
    }
    public void UseSkill()
    {
        if (skill_Item != null)
        {
            Canvas_Manager.Instance.player.CreateSkillObject(skill_Item);
        }
    }
}