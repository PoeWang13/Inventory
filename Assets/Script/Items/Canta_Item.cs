using UnityEngine;

[CreateAssetMenu(menuName = "Item/Canta Item")]
public class Canta_Item : Item
{
    [Header("Inventory'e eklenecek slot sayısını belirler.")]
    [SerializeField] private int bagAdet;
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.CantaEkle(this);
    }
    public int BagAdetSayisi()
    {
        return bagAdet;
    }
}