

public class Reward_Slot : Slot
{
    /// ödül slot        : Sol tık - inventory gonder
    public override void LeftClick()
    {
        if (myInventory.ItemEkle(item, itemAmount).Item2 != 0)
        {
            Canvas_Manager.Instance.UyariYap("You don't take all REWARD.");
        }
        SlotButtonInterac(false);
        Tool_Manager.Instance.CloseTool();
    }
}