using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Fire_Arrow_Object : Skill_Object
{
    [Header("Fire Arrow Skill")]
    public Fire_Arrow_Skill fire_Arrow_Skill;
    public override void StartSkill(Vector3 direction)
    {
        if (myOwner.manaStat.StatValue >= fire_Arrow_Skill.mana)
        {
            myOwner.manaStat.RemoveStatCore(fire_Arrow_Skill.mana);
            for (int e = fire_Arrow_Skill.mySlots.Count - 1; e >= 0; e--)
            {
                if (fire_Arrow_Skill.mySlots[e] == null)
                {
                    fire_Arrow_Skill.mySlots.RemoveAt(e);
                }
            }
            for (int e = 0; e < fire_Arrow_Skill.mySlots.Count; e++)
            {
                fire_Arrow_Skill.mySlots[e].UseCooldDownImage(1);
                fire_Arrow_Skill.mySlots[e].SlotButtonInterac(false);
            }
            Instantiate(fire_Arrow_Skill.fireArrowPrefab, exitPos, Quaternion.identity).SetBullet(direction);
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("Yeteri kadar manan yok.");
            Destroy(gameObject);
        }
    }
    public override void AddSkillSlot(Slot slot)
    {
        if (!fire_Arrow_Skill.mySlots.Contains(slot))
        {
            fire_Arrow_Skill.mySlots.Add(slot);
        }
    }
    public override void RemoveSkillSlot(Slot slot)
    {
        fire_Arrow_Skill.mySlots.Remove(slot);
    }
    private void Update()
    {
        fire_Arrow_Skill.coolDownNext += Time.deltaTime;
        for (int e = 0; e < fire_Arrow_Skill.mySlots.Count; e++)
        {
            fire_Arrow_Skill.mySlots[e].UseCooldDownImage(1 - (fire_Arrow_Skill.coolDownNext / fire_Arrow_Skill.coolDown));
        }
        if (fire_Arrow_Skill.coolDownNext >= fire_Arrow_Skill.coolDown)
        {
            fire_Arrow_Skill.coolDownNext = 0;
            for (int e = 0; e < fire_Arrow_Skill.mySlots.Count; e++)
            {
                fire_Arrow_Skill.mySlots[e].SlotButtonInterac(true);
            }
            DestroySkill();
        }
    }
    public override void ClearSlots()
    {
        fire_Arrow_Skill.mySlots.Clear();
    }
}