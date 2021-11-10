
public class Equip_Manager_Npc : Equip_Manager
{
    private Npc npc;
    private void Start()
    {
        npc = GetComponent<Npc>();
        EquipAllItems();
    }
    /// <summary>
    /// Elbise parçasını göstermek için giyer
    /// </summary>
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
    /// <summary>
    /// Tum elbiseleri göstermek için giyer
    /// </summary>
    public void EquipAllItems()
    {
        for (int e = 0; e < npc.equip_Items.Count; e++)
        {
            if (npc.equip_Items[e].equip_Item != null)
            {
                ItemEquipNpc(npc.equip_Items[e].equip_Item);
            }
        }
    }
    public void UnEquipAllItems(int itemNo)
    {
        UnEquip(npc.equip_Items[itemNo].equip_Item);
        npc.equip_Items[itemNo] = null;
    }
}