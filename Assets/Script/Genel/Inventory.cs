using UnityEngine;
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
    public Canta_Item firstCanta;
    public Equip_Manager_Player equip_Manager_Player;
    [SerializeField] private List<Bag_Slot> inventorySlot = new List<Bag_Slot>();
    [SerializeField] private List<Canta_Slot> cantaSlot = new List<Canta_Slot>();

    private void Start()
    {
        if (firstCanta != null)
        {
            CantaEkle(firstCanta);
        }
    }
    #region Inventory
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
        return (-1, itemCount);
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
    /// <summary>
    /// Boþ slot var mý? Varsa kaç adet
    /// </summary>
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
    /// <summary>
    /// Çanta ekliyecek yer varsa çantayý ve ondaki bag miktarý kadar inventory slotunu ekler.
    /// </summary>
    public void CantaEkle(Canta_Item canta_Item)
    {
        Canta_Slot canta = null;
        bool bosCanta = false;
        int bag = canta_Item.BagAdetSayisi();
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
            canta.SlotDoldur(canta_Item, bag);
            for (int e = 0; e < bag; e++)
            {
                inventorySlot.Add(Instantiate(Canvas_Manager.Instance.bag_Slot, Canvas_Manager.Instance.bagSlotParent));
            }
        }
    }
    /// <summary>
    /// Çantayý eðer yedekte çanta varsa en geriden baþlayarak içindekilerle beraber siler.
    /// </summary>
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
            int bagAdet = (canta_Slot.item as Canta_Item).BagAdetSayisi();
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