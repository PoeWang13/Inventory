using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum ItemType { Genel, Potion, Equip, Skill, Craft }
public class Item : ScriptableObject
{
    public string myName;
    public string myDesc;
    public Sprite myIcon;
    public ItemType itemType;
    public int itemPrice;
    public int maxAmount;
    public bool isPriceTl;

    public virtual void UseItem(Slot mySlot, Inventory myInventory)
    {

    }
    public virtual void HasEffect(Slot mySlot)
    {

    }
    public virtual string ItemSpecial()
    {
        return "";
    }
}