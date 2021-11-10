
public class Canta_Slot : Slot
{
    /// çanta slot       : orta tık - yere at
    public override void MiddleClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (myInventory.CantaSil(this))
        {
            SlotBosalt();
        }
    }
}