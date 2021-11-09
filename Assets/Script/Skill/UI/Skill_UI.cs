using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Skill_UI : MonoBehaviour
{
    public Skill_Item skill_Item;
    public Skill_Slot skill_Slot;
    public Skill_Object skill_Object;

    public void SetSkillUI()
    {
        skill_Item.skill_Object.GetComponent<Skill_Object>().AddSkillSlot(skill_Slot);
        skill_Slot.SlotDoldur(skill_Item, 1);
        if (skill_Item.IsPasif())
        {
            skill_Slot.SlotButtonInterac(false);
        }
    }
}