using UnityEngine;

[CreateAssetMenu(menuName = "Item/Canta Item")]
public class Canta_Item : Item
{
    public int bagAdet;
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.CantaEkle(this);
    }
}