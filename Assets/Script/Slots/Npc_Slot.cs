using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Npc_Slot : Slot
{
    private Player player;
    /// npc slot         : Sol tık - 1 tane satın al + orta tık - max oranda satın al
    public override void LeftClick()
    {
        if (Canvas_Manager.Instance.IsOpenCarrierSlot())
        {
            if (Canvas_Manager.Instance.CarrieedSlot() is Bag_Slot)
            {
                if (Canvas_Manager.Instance.CarrierSlotItem() is Skill_Item)
                {
                    return;
                }
                player.myMoney += (int)(item.itemPrice * 0.5f);
                Canvas_Manager.Instance.CarriedSlotBosalt();
            }
        }
        else
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }
            if (player.myMoney >= item.itemPrice)
            {
                Canvas_Manager.Instance.player.myInventory.ItemEkle(item, 1);
                player.myMoney -= item.itemPrice;
            }
            else
            {
                Canvas_Manager.Instance.UyariYap("You don't have Money.");
            }
        }
        Tool_Manager.Instance.CloseTool();
    }
    public override void MiddleClick()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if (player.myMoney >= item.itemPrice * item.maxAmount)
        {
            Canvas_Manager.Instance.player.myInventory.ItemEkle(item, item.maxAmount);
            player.myMoney -= item.itemPrice * item.maxAmount;
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("You don't have Money.");
        }
    }
}