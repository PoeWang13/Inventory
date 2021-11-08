using UnityEngine;
using System.Collections.Generic;

public class Canta_Manager : MonoBehaviour
{
    public Player player;
    public Inventory myInventory;

    #region Canta
    public List<Canta_Slot> cantaSlot = new List<Canta_Slot>();
    public void CantaEkle(int bagAdet)
    {
        int cantaAdet = 0;
        for (int e = 0; e < cantaSlot.Count; e++)
        {
            if (cantaSlot[e].SlotDolumu())
            {
                cantaAdet++;
            }
        }
        if (cantaAdet < 10)
        {
            for (int e = 0; e < bagAdet; e++)
            {
                myInventory.inventorySlot.Add(Instantiate(Canvas_Manager.Instance.bag_Slot, Canvas_Manager.Instance.bagSlotParent));
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
            for (int e = myInventory.inventorySlot.Count - 1; e >= 0 && bagAdet != 0; e--)
            {
                bagAdet--;
                myInventory.inventorySlot.RemoveAt(e);
                Destroy(myInventory.inventorySlot[e].gameObject);
            }
            return true;
        }
        Canvas_Manager.Instance.UyariYap("You can't delete last Bag.");
        return false;
    }
    #endregion
}