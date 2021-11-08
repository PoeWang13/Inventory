using UnityEngine;
using System.Collections.Generic;

public class Equip_Manager_Player : Equip_Manager
{
    public Inventory myInventory;
    #region Equip
    public List<Equip_Slot> equipSlot = new List<Equip_Slot>();
    public void ItemEquip(Equip_Item equip_Item, Slot mySlot)
    {
        for (int e = 0; e < equipSlot.Count; e++)
        {
            if (equipSlot[e].bodyPart == equip_Item.bodyPart)
            {
                if (equip_Item.ciftKol)
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
    #endregion
}