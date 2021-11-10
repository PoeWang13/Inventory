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
    [Header("Yapılacak item.")]
    public Item myObject;
    [Header("Yapılacak item adedi.")]
    public int yapimAdet;

    [Header("Icinde yer aldığı listenin Containeri.")]
    [SerializeField] private Craft_List_Conteiner myContainer;
    [Header("Yapılacak item için gerekli item ve sayıları.")]
    public List<CraftMalzeme> craftMalzemes = new List<CraftMalzeme>();
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        if (!myContainer.HasCratItem(this))
        {
            myContainer.AddCratItem(this);
            mySlot.SlotBosalt();
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("You have this Craft Method.");
        }
    }
    public override string ItemSpecial()
    {
        return "Crafting Amount : " + yapimAdet;
    }
}