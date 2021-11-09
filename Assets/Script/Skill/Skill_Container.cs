using UnityEngine;


[CreateAssetMenu(menuName = "Item/Skill Container", fileName = "Container_Skill_")]
public class Skill_Container : Item
{
    public Skill_Item skill_Item;
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.player.AddSkill(skill_Item);
    }
}