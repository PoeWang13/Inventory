using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Bag_Slot : Slot
{
    /// taşınabilir slotlar
    /// bag-key bar-equip-skill-bank-
    /// taşı
    public override void LeftClick()
    {
        if (coolDownImage.fillAmount > 0)
        {
            Canvas_Manager.Instance.CloseCarrierSlot();
            return;
        }
        if (SlotDolumu())
        {
            if (!Canvas_Manager.Instance.IsOpenCarrierSlot())
            {
                Canvas_Manager.Instance.OpenCarrierSlot(this);
            }
            else
            {
                Canvas_Manager.Instance.UsedCarrierSlot(this);
            }
        }
        else
        {
            if (Canvas_Manager.Instance.IsOpenCarrierSlot())
            {
                Canvas_Manager.Instance.UsedCarrierSlot(this);
            }
        }
        Tool_Manager.Instance.CloseTool();
    }
    /// yere at
    public override void MiddleClick()
    {
        if (item != null)
        {
            if (item is Skill_Item)
            {
                (item as Skill_Item).skill_Object.GetComponent<Skill_Object>().RemoveSkillSlot(this);
                SlotBosalt();
            }
            else
            {
                Game_Manager.Instance.CreateItemBox(item, itemAmount);
            }
            SlotBosalt();
        }
    }
    /// kullan
    public override void RightClick()
    {
        if (item != null)
        {
            item.UseItem(this, Canvas_Manager.Instance.player.myInventory);
            SlotItemKullan();
        }
    }
}