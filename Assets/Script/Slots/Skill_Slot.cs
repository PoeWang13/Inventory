using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Skill_Slot : Slot
{
    /// skill slot       : Sol tık - taşı + sağ tık - kullan
    public override void LeftClick()
    {
        if (coolDownImage.fillAmount > 0)
        {
            Canvas_Manager.Instance.CloseCarrierSlot();
            return;
        }
        if (Canvas_Manager.Instance.IsOpenCarrierSlot())
        {
            Canvas_Manager.Instance.CloseCarrierSlot();
        }
        else
        {
            Canvas_Manager.Instance.OpenCarrierSlot(this);
        }
        Tool_Manager.Instance.CloseTool();
    }
    public override void MiddleClick()
    {
        Canvas_Manager.Instance.player.RemoveSkill(item as Skill_Item);
    }
    public override void RightClick()
    {
        if (coolDownImage.fillAmount == 0)
        {
            Canvas_Manager.Instance.player.CreateSkillObject(item as Skill_Item);
        }
    }
}