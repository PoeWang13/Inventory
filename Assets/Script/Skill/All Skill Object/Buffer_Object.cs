using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Buffer_Object : Skill_Object
{
    [Header("Buffer Skill")]
    public Skill_Buffer skill_Buffer;
    public override void StartSkill(Vector3 direction)
    {
        for (int e = skill_Buffer.mySlots.Count - 1; e >= 0; e--)
        {
            if (skill_Buffer.mySlots[e] == null)
            {
                skill_Buffer.mySlots.RemoveAt(e);
            }
        }
        for (int e = 0; e < skill_Buffer.mySlots.Count; e++)
        {
            skill_Buffer.mySlots[e].SlotButtonInterac(false);
            skill_Buffer.mySlots[e].usedImage.gameObject.SetActive(true);
        }
        if (skill_Buffer.isPercent)
        {
            myOwner.MyStat(skill_Buffer.buffName).AddYuzdeStat(skill_Buffer.buffAmount);
        }
        else
        {
            myOwner.MyStat(skill_Buffer.buffName).AddStat(skill_Buffer.buffAmount);
        }
    }
    #region Slot - Pasif
    public override void AddSkillSlot(Slot slot)
    {
        if (!skill_Buffer.mySlots.Contains(slot))
        {
            skill_Buffer.mySlots.Add(slot);
        }
    }
    public override void RemoveSkillSlot(Slot slot)
    {
        skill_Buffer.mySlots.Remove(slot);
    }
    public override void ClearSlots()
    {
        skill_Buffer.mySlots.Clear();
    }
    public override bool IsPasif()
    {
        return skill_Buffer.isPasif;
    }
    #endregion
}