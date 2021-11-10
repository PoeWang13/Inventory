using UnityEngine;
using TMPro;

public class KeyBar_Slot : Slot
{
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
            if (Canvas_Manager.Instance.IsOpenCarrierSlot())
            {
                Canvas_Manager.Instance.CloseCarrierSlot();
            }
            item.UseItem(this, Canvas_Manager.Instance.player.myInventory);
            if (!(item is Skill_Item))
            {
                SlotItemKullan();
            }
        }
    }
    [Header("Key Bar Part")]
    public KeyCode keyCode;

    // Update
    public void Update()
    {
        if (Input.GetKey(keyCode))
        {
            if (item != null)
            {
                item.UseItem(this, Canvas_Manager.Instance.player.myInventory);
                if (!(item is Skill_Item))
                {
                    SlotItemKullan();
                }
            }
        }
    }
}