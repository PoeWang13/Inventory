using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Item/Skill Item")]
public class Skill_Item : Item
{
    public Skill_Object skill_Object;
    [SerializeField] private GameObject slotEffect;
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.player.CreateSkillObject(this);
    }
    public override void HasEffect(Slot mySlot)
    {
        if (slotEffect != null)
        {
            mySlot.SlotHasEffect(slotEffect);
        }
    }
    public bool IsPasif()
    {
        if (skill_Object != null)
        {
            return skill_Object.IsPasif();
        }
        return false;
    }
}