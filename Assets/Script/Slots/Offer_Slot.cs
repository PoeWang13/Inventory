using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Offer_Slot : Slot
{
    private Player player;
    /// teklif slot      : Sol tık - satın alıp inventory gonder
    public override void LeftClick()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if (player.myMoney >= item.itemPrice)
        {
            int alinabilirItem = player.myMoney / item.itemPrice;
            if (alinabilirItem >= itemAmount)
            {
                player.myMoney -= itemAmount * item.itemPrice;
                myInventory.ItemEkle(item, itemAmount);
                SlotButtonInterac(false);
            }
            else
            {
                myInventory.ItemEkle(item, alinabilirItem);
                SlotAdetItemKullan(alinabilirItem);
                player.myMoney -= alinabilirItem * item.itemPrice;
                Canvas_Manager.Instance.UyariYap("You don't take all Offers.");
            }
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("You don't have Money.");
        }
        Tool_Manager.Instance.CloseTool();
    }
}