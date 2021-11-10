using UnityEngine;

public class Npc_Slot : Slot
{
    private Player player;
    /// npc slot         : Sol tık - 1 tane satın al + orta tık - max oranda satın al
    public override void LeftClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (Canvas_Manager.Instance.IsOpenCarrierSlot())
        {
            if (Canvas_Manager.Instance.CarrieedSlot() is Bag_Slot)
            {
                if (Canvas_Manager.Instance.CarrierSlotItem() is Skill_Item)
                {
                    return;
                }
                player.AddLevelExp((int)(item.itemPrice * 0.5f));
                Canvas_Manager.Instance.CarriedSlotBosalt();
            }
        }
        else
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }
            if (player.RemoveMyExp(item.itemPrice))
            {
                Canvas_Manager.Instance.player.myInventory.ItemEkle(item, 1);
            }
            else
            {
                Canvas_Manager.Instance.UyariYap("You don't have Exp.");
            }
        }
        Tool_Manager.Instance.CloseTool();
    }
    public override void MiddleClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if (player.RemoveMyExp(item.itemPrice * item.maxAmount))
        {
            Canvas_Manager.Instance.player.myInventory.ItemEkle(item, item.maxAmount);
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("You don't have Exp.");
        }
    }
}