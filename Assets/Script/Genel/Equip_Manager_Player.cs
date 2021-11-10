using System.Collections.Generic;

public class Equip_Manager_Player : Equip_Manager
{
    private Inventory myInventory;
    public List<EquipDurum> equip_Items = new List<EquipDurum>();
    public List<Equip_Slot> equipSlot = new List<Equip_Slot>();
    private void Start()
    {
        myInventory = GetComponent<Inventory>();
    }
    #region Equip
    /// <summary>
    /// Elbiseyi ilgili slota kurallar(doğru yermi ?, item tek el mi- çift elmi gibi) dağilinde ekler
    /// </summary>
    public void ItemEquip(Equip_Item equip_Item, Slot mySlot)
    {
        for (int e = 0; e < equipSlot.Count; e++)
        {
            if (equipSlot[e].bodyPart == equip_Item.bodyPart)
            {
                if (equip_Item.IsCiftKol())
                {
                    int yerLazim = 0;
                    if (equipSlot[e].SlotDolumu())
                    {
                        yerLazim++;
                    }
                    if (equipSlot[e + 1].SlotDolumu())
                    {
                        yerLazim++;
                    }
                    if (yerLazim == 0)
                    {
                        equipSlot[e].SlotDoldur(equip_Item, 1);
                        Equip(equip_Item);
                    }
                    else if (yerLazim == 1)
                    {
                        if (myInventory.BosSlotVar().Item1)
                        {
                            Equip_Item item1 = equipSlot[e].item as Equip_Item;
                            Equip_Item item2 = equipSlot[e + 1].item as Equip_Item;
                            mySlot.SlotBosalt();
                            if (item1 != null)
                            {
                                UnEquip(item1);
                                equipSlot[e].SlotBosalt();
                                myInventory.ItemEkle(item1, 1);
                                Equip(item1);
                            }
                            if (item2 != null)
                            {
                                equipSlot[e + 1].SlotBosalt();
                                myInventory.ItemEkle(item2, 1);
                                Equip(equip_Item);
                            }
                            equipSlot[e].SlotDoldur(equip_Item, 1);
                        }
                    }
                    else if (yerLazim == 2)
                    {
                        if (myInventory.BosSlotVar().Item2 > 1)
                        {
                            Item item1 = equipSlot[e].item;
                            Item item2 = equipSlot[e + 1].item;
                            equipSlot[e].SlotDoldur(equip_Item, 1);
                            mySlot.SlotBosalt();
                            equipSlot[e + 1].SlotBosalt();
                            myInventory.ItemEkle(item1, 1);
                            myInventory.ItemEkle(item2, 1);
                        }
                    }
                }
                else
                {
                    if (equipSlot[e].SlotDolumu())
                    {
                        if (myInventory.BosSlotVar().Item1)
                        {
                            Item item = equipSlot[e].item;
                            equipSlot[e].SlotDoldur(equip_Item, 1);
                            myInventory.ItemEkle(item, 1);
                        }
                    }
                    else
                    {
                        equipSlot[e].SlotDoldur(equip_Item, 1);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Body parçasının bağlı olduğu equip slotun numarasını geri dönderir.
    /// </summary>
    public int EquipSlotNo(Body_Part body_Part)
    {
        for (int e = 0; e < equipSlot.Count; e++)
        {
            if (body_Part == equipSlot[e].bodyPart)
            {
                return e;
            }
        }
        return -1;
    }
    public void EquipItemsGiy(Body_Part body_Part, Equip_Item equip_Item)
    {
        bool giydim = false;
        for (int e = 0; e < equip_Items.Count && !giydim; e++)
        {
            if (equip_Items[e].bodyPart == body_Part)
            {
                equip_Items[e].equip_Item = equip_Item;
                giydim = true;
            }
        }
    }
    #endregion
}