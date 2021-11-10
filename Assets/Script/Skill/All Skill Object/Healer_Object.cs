using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Healer_Object : Skill_Object
{
    [Header("Healer Skill")]
    public Skill_Healer skill_Healer;
    private bool giveLife;
    public override void StartSkill(Vector3 direction)
    {
        myOwner.lifeStat.OnStatChanced += LifeStat_OnStatChanced;
        for (int e = skill_Healer.mySlots.Count - 1; e >= 0; e--)
        {
            if (skill_Healer.mySlots[e] == null)
            {
                skill_Healer.mySlots.RemoveAt(e);
            }
        }
        for (int e = 0; e < skill_Healer.mySlots.Count; e++)
        {
            skill_Healer.mySlots[e].SlotButtonInterac(false);
            skill_Healer.mySlots[e].usedImage.gameObject.SetActive(true);
        }
    }
    private void LifeStat_OnStatChanced(object sender, System.EventArgs e)
    {
        giveLife = true;
    }
    private void Update()
    {
        if (giveLife)
        {
            skill_Healer.coolDownNext += Time.deltaTime;
            if (skill_Healer.coolDownNext >= skill_Healer.coolDown)
            {
                if (myOwner.lifeStat.StatValue < myOwner.myStats[0].StatValue)
                {
                    skill_Healer.coolDownNext = 0;
                    if (skill_Healer.isPercent)
                    {
                        int heal = (int)(myOwner.myStats[0].StatValue * skill_Healer.healAmount * 0.01f);
                        myOwner.lifeStat.AddStatCore(heal);
                    }
                    else
                    {
                        myOwner.lifeStat.AddStatCore(skill_Healer.healAmount);
                    }
                    if (myOwner.lifeStat.StatValue >= myOwner.myStats[0].StatValue)
                    {
                        myOwner.lifeStat.SetStatCore(myOwner.myStats[0].StatValue);
                        giveLife = false;
                    }
                }
            }
        }
    }
    #region Slot - Pasif
    public override void AddSkillSlot(Slot slot)
    {
        if (!skill_Healer.mySlots.Contains(slot))
        {
            skill_Healer.mySlots.Add(slot);
        }
    }
    public override void RemoveSkillSlot(Slot slot)
    {
        skill_Healer.mySlots.Remove(slot);
    }
    public override void ClearSlots()
    {
        skill_Healer.mySlots.Clear();
    }
    public override bool IsPasif()
    {
        return skill_Healer.isPasif;
    }
    public override (int, int) Mana_Cooldown()
    {
        return (skill_Healer.mana, skill_Healer.coolDown);
    }
    #endregion
}