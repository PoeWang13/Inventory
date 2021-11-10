using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ItemDurum
{
    public Item item;
    public int itemAmount;
}
public class Inventory : MonoBehaviour
{
    public Player player;
    public Equip_Manager_Player equip_Manager_Player;

    public List<Bag_Slot> inventorySlot = new List<Bag_Slot>();
    #region Canta
    public List<Canta_Slot> cantaSlot = new List<Canta_Slot>();
    /// <summary>
    /// Objenin Inventory'sinde belirtilen itemden kaç adet olduðunu döner.
    /// </summary>
    public int KacAdetItemVar(Item item)
    {
        int itemAmount = 0;
        for (int e = 0; e < inventorySlot.Count; e++)
        {
            if (inventorySlot[e].item == item)
            {
                itemAmount += inventorySlot[e].itemAmount;
            }
        }
        return itemAmount;
    }
    /// <summary>
    /// Objenin Inventory'sine item ekler.ilk int en son eklendiði yeri, 2. int ise kaç tane eklenmediðini söyler
    /// </summary>
    public (int, int) ItemEkle(Item item, int itemAmount)
    {
        int itemCount = itemAmount;
        for (int e = 0; e < inventorySlot.Count; e++)
        {
            if (inventorySlot[e].item == null)
            {
                if (itemCount > item.maxAmount)
                {
                    itemCount -= item.maxAmount;
                    inventorySlot[e].SlotDoldur(item, item.maxAmount);
                }
                else
                {
                    inventorySlot[e].SlotDoldur(item, itemCount);
                    return (e, 0);
                }
            }
            else if (inventorySlot[e].item == item)
            {
                itemCount = inventorySlot[e].SlotEksikAmountDoldur(itemCount);
                if (itemCount == 0)
                {
                    return (e, 0);
                }
            }
            else if (inventorySlot[e].item != item)
            {
                continue;
            }
        }
        return (-1, itemAmount - itemCount);
    }
    /// <summary>
    /// Objenin Inventory'sinden item siler.true ise itemin hepsi silinmiþ demektir.
    /// </summary>
    public bool ItemSil(Item item, int itemAmount)
    {
        int itemToplam = itemAmount;
        for (int e = 0; e < inventorySlot.Count && itemToplam != 0; e++)
        {
            if (inventorySlot[e].item == item)
            {
                itemToplam -= inventorySlot[e].SlotAdetItemKullan(itemToplam);
            }
        }
        return itemToplam == 0;
    }
    public (bool, int) BosSlotVar()
    {
        int bosSayisi = 0;
        for (int e = 0; e < inventorySlot.Count; e++)
        {
            if (!inventorySlot[e].SlotDolumu())
            {
                bosSayisi++;
            }
        }
        return (bosSayisi > 0, bosSayisi);
    } 
    #endregion

    #region Canta
    public void CantaEkle(Canta_Item canta_Item)
    {
        Canta_Slot canta = null;
        bool bosCanta = false;
        for (int e = 0; e < cantaSlot.Count && !bosCanta; e++)
        {
            if (!cantaSlot[e].SlotDolumu())
            {
                canta = cantaSlot[e];
                bosCanta = true;
            }
        }
        if (bosCanta)
        {
            canta.SlotDoldur(canta_Item, canta_Item.bagAdet);
            for (int e = 0; e < canta_Item.bagAdet; e++)
            {
                inventorySlot.Add(Instantiate(Canvas_Manager.Instance.bag_Slot, Canvas_Manager.Instance.bagSlotParent));
            }
        }
    }
    public bool CantaSil(Canta_Slot canta_Slot)
    {
        int cantaAdet = 0;
        for (int e = 0; e < cantaSlot.Count; e++)
        {
            if (cantaSlot[e].SlotDolumu())
            {
                cantaAdet++;
            }
        }
        if (cantaAdet > 1)
        {
            int bagAdet = (canta_Slot.item as Canta_Item).bagAdet;
            for (int e = inventorySlot.Count - 1; e >= 0 && bagAdet != 0; e--)
            {
                bagAdet--;
                inventorySlot.RemoveAt(e);
                Destroy(inventorySlot[e].gameObject);
            }
            return true;
        }
        Canvas_Manager.Instance.UyariYap("You can't delete last Bag.");
        return false;
    } 
    #endregion
}