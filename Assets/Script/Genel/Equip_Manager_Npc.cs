
public class Equip_Manager_Npc : Equip_Manager
{
    public override void Start()
    {
        base.Start();
        EquipAllItems();
    }
    /// <summary>
    /// Elbise parçasını göstermek için giyer
    /// </summary>
    public void ItemEquipNpc(Equip_Item equip_Item)
    {
        for (int e = 0; e < equip_Items.Count; e++)
        {
            if (equip_Item.bodyPart == equip_Items[e].bodyPart)
            {
                Canvas_Manager.Instance.otherEquip_Slots[e].SlotDoldur(equip_Item, 1);
                Equip(equip_Item);
            }
        }
    }
    /// <summary>
    /// Tum elbiseleri göstermek için giyer
    /// </summary>
    public void EquipAllItems()
    {
        for (int e = 0; e < equip_Items.Count; e++)
        {
            if (equip_Items[e].equip_Item != null)
            {
                ItemEquipNpc(equip_Items[e].equip_Item);
            }
        }
    }
    public void UnEquipAllItems(int itemNo)
    {
        UnEquip(equip_Items[itemNo].equip_Item);
        equip_Items[itemNo] = null;
    }
}