using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class CraftMalzeme
{
    public Item item;
    public int amount;
}
[CreateAssetMenu(menuName = "Item/Craft Item")]
public class Craft_Item : Item
{
    public Item myObject;
    public int yapimAdet;
    public Craft_List_Conteiner myContainer;
    public List<CraftMalzeme> craftMalzemes = new List<CraftMalzeme>();
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        if (!myContainer.craftLists.Contains(this))
        {
            myContainer.craftLists.Add(this);
            mySlot.SlotBosalt();
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("You have this Craft Method.");
        }
    }
}