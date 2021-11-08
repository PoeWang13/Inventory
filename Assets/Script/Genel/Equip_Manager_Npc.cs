using System.Collections.Generic;

public class Equip_Manager_Npc : Equip_Manager
{
    public Npc npc;
    private void Start()
    {
        EquipAllItems();
    }
    public void ItemEquipNpc(Equip_Item equip_Item)
    {
        for (int e = 0; e < npc.equip_Items.Count; e++)
        {
            if (equip_Item.bodyPart == npc.equip_Items[e].bodyPart)
            {
                Canvas_Manager.Instance.otherEquip_Slots[e].SlotDoldur(equip_Item, 1);
                Equip(equip_Item);
            }
        }
    }
    public void EquipAllItems()
    {
        for (int e = 0; e < npc.equip_Items.Count; e++)
        {
            ItemEquipNpc(npc.equip_Items[e].equip_Item);
        }
    }
    public void UnEquipAllItems(int itemNo)
    {
        UnEquip(npc.equip_Items[itemNo].equip_Item);
        npc.equip_Items[itemNo] = null;
    }
}