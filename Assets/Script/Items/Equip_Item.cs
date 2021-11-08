using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Item/Equip Item")]
public class Equip_Item : Item
{
    public Body_Part bodyPart;
    public bool ciftKol;
    public List<Stat> myStats = new List<Stat>();
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.equip_Manager_Player.ItemEquip(this, mySlot);
    }
    public void UseSkill()
    {

    }
}