using UnityEngine;

public class Offer_Slot : Slot
{
    private Player player;
    /// teklif slot      : Sol tık - satın alıp inventory gonder
    public override void LeftClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if (player.CheckMyExp(item.itemPrice))
        {
            int alinabilirItem = player.HowManyMyExp() / item.itemPrice;
            if (alinabilirItem >= itemAmount)
            {
                player.RemoveMyExp(itemAmount * item.itemPrice);
                myInventory.ItemEkle(item, itemAmount);
                SlotButtonInterac(false);
            }
            else
            {
                myInventory.ItemEkle(item, alinabilirItem);
                SlotAdetItemKullan(alinabilirItem);
                player.RemoveMyExp(alinabilirItem * item.itemPrice);
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