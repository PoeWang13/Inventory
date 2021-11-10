using TMPro;
using UnityEngine;
using System.Text;

public class Skill_UI : MonoBehaviour
{
    private Skill_Item skill_Item;
    private Skill_Slot skill_Slot;
    public TextMeshProUGUI skillText;
    private StringBuilder sb = new StringBuilder();

    public void SetSkillUI(Skill_Item item)
    {
        skill_Item = item;
        skill_Slot = GetComponentInChildren<Skill_Slot>();
        Skill_Object skill_Object = skill_Item.skill_Object.GetComponent<Skill_Object>();
        skill_Object.AddSkillSlot(skill_Slot);
        skill_Slot.SlotDoldur(skill_Item, 1);
        if (skill_Item.IsPasif())
        {
            skill_Slot.SlotButtonInterac(false);
            skillText.text = "Pasif Skill";
        }
        else
        {
            (int, int) mana_Cooldown = skill_Object.Mana_Cooldown();
            sb.Length = 0;
            sb.Append("Aktif Skill");
            sb.AppendLine();
            sb.Append("Mana: " + mana_Cooldown.Item1);
            sb.AppendLine();
            sb.Append("Cooldown : " + mana_Cooldown.Item2);
            skillText.text = sb.ToString();
        }
    }
}