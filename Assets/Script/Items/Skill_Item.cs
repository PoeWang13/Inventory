﻿
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Item/Skill Item")]
public class Skill_Item : Item
{
    public bool isPasif;
    public Skill_Object skill_Object;
    public GameObject slotEffect;
    public Skill_UI skillUI;
    public override void UseItem(Slot mySlot, Inventory myInventory)
    {
        myInventory.player.CreateSkillObject(this);
    }
    public override void HasEffect(Slot mySlot)
    {
        if (slotEffect != null)
        {
            mySlot.SlotHasEffect(slotEffect);
        }
    }
}