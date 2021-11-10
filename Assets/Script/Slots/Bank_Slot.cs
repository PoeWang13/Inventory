
public class Bank_Slot : Slot
{
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
                if (SlotDolumu())
                {
                    if (Canvas_Manager.Instance.CarrierSlotItem().myName != item.myName)
                    {
                        Item item1 = Canvas_Manager.Instance.CarrieedSlot().item;
                        int item2 = Canvas_Manager.Instance.CarrieedSlot().itemAmount;
                        Canvas_Manager.Instance.CarrieedSlot().SlotDoldur(item, itemAmount);
                        SlotDoldur(item1, item2);
                    }
                    else
                    {
                        int item2 = Canvas_Manager.Instance.CarrieedSlot().itemAmount;
                        item2 = SlotEksikAmountDoldur(item2);
                        if (item2 == 0)
                        {
                            Canvas_Manager.Instance.CarrieedSlot().SlotBosalt();
                        }
                        else
                        {
                            Canvas_Manager.Instance.CarrieedSlot().SlotDoldur(item, item2);
                        }
                    }
                }
                else
                {
                    SlotDoldur(Canvas_Manager.Instance.CarrieedSlot().item, Canvas_Manager.Instance.CarrieedSlot().itemAmount);
                    Canvas_Manager.Instance.CarrieedSlot().SlotBosalt();
                }
            }
            Canvas_Manager.Instance.CloseCarrierSlot();
        }
        else
        {
            if (SlotDolumu())
            {
                if (Canvas_Manager.Instance.player.myInventory.BosSlotVar().Item1)
                {
                    Canvas_Manager.Instance.player.myInventory.ItemEkle(item, itemAmount);
                    SlotBosalt();
                }
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
        if (item != null)
        {
            if (Canvas_Manager.Instance.IsOpenCarrierSlot())
            {
                Canvas_Manager.Instance.CloseCarrierSlot();
            }
            Game_Manager.Instance.CreateItemBox(item, itemAmount);
            SlotBosalt();
        }
    }
    /// inventory gonder
    public override void RightClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (Canvas_Manager.Instance.IsOpenCarrierSlot())
        {
            Canvas_Manager.Instance.CloseCarrierSlot();
        }
        itemAmount = Canvas_Manager.Instance.player.myInventory.ItemEkle(item, itemAmount).Item2;
        if (itemAmount == 0)
        {
            SlotBosalt();
        }
    }
}