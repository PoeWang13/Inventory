using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Craft_Slot : Slot
{
    /// craft slot       : Sol tık - yap
    public override void LeftClick()
    {
        Craft_Item craft_Item = item as Craft_Item;
        bool yapabilirim = true;
        for (int e = 0; e < craft_Item.craftMalzemes.Count && yapabilirim; e++)
        {
            if (myInventory.KacAdetItemVar(craft_Item.craftMalzemes[e].item) < craft_Item.craftMalzemes[e].amount)
            {
                yapabilirim = false;
                Canvas_Manager.Instance.UyariYap("You don't have <color=red>" + craft_Item.craftMalzemes[e].item.myName + "</color>");
            }
        }
        if (yapabilirim)
        {
            for (int e = 0; e < craft_Item.craftMalzemes.Count && yapabilirim; e++)
            {
                myInventory.ItemSil(craft_Item.craftMalzemes[e].item, craft_Item.craftMalzemes[e].amount);
            }
            myInventory.ItemEkle(craft_Item.myObject, craft_Item.yapimAdet);
        }
    }
}