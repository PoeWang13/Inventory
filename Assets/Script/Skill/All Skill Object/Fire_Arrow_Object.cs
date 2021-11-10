using UnityEngine;

public class Fire_Arrow_Object : Skill_Object
{
    [Header("Fire Arrow Skill")]
    public Skill_Fire_Arrow skill_Fire_Arrow;
    public override void StartSkill(Vector3 direction)
    {
        if (myOwner.manaStat.StatValue >= skill_Fire_Arrow.mana)
        {
            // Ýðtiyaç duyulan manayý düþ
            myOwner.manaStat.RemoveStatCore(skill_Fire_Arrow.mana);
            // Kalmýþ slotlarý sil
            for (int e = skill_Fire_Arrow.mySlots.Count - 1; e >= 0; e--)
            {
                if (skill_Fire_Arrow.mySlots[e] == null)
                {
                    skill_Fire_Arrow.mySlots.RemoveAt(e);
                }
            }
            // Slotlarý kullanýlmaya baþlanmýþ göster.
            for (int e = 0; e < skill_Fire_Arrow.mySlots.Count; e++)
            {
                skill_Fire_Arrow.mySlots[e].UseCooldDownImage(1);
                skill_Fire_Arrow.mySlots[e].SlotButtonInterac(false);
            }
            Instantiate(skill_Fire_Arrow.fireArrowPrefab, exitPos, Quaternion.identity).SetBullet(direction);
        }
        else
        {
            Canvas_Manager.Instance.UyariYap("Yeteri kadar manan yok.");
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        skill_Fire_Arrow.coolDownNext += Time.deltaTime;
        for (int e = 0; e < skill_Fire_Arrow.mySlots.Count; e++)
        {
            skill_Fire_Arrow.mySlots[e].UseCooldDownImage(1 - (skill_Fire_Arrow.coolDownNext / skill_Fire_Arrow.coolDown));
        }
        if (skill_Fire_Arrow.coolDownNext >= skill_Fire_Arrow.coolDown)
        {
            skill_Fire_Arrow.coolDownNext = 0;
            for (int e = 0; e < skill_Fire_Arrow.mySlots.Count; e++)
            {
                skill_Fire_Arrow.mySlots[e].SlotButtonInterac(true);
            }
            DestroySkill();
        }
    }
    #region Slot - Pasif
    public override void AddSkillSlot(Slot slot)
    {
        if (!skill_Fire_Arrow.mySlots.Contains(slot))
        {
            skill_Fire_Arrow.mySlots.Add(slot);
        }
    }
    public override void RemoveSkillSlot(Slot slot)
    {
        skill_Fire_Arrow.mySlots.Remove(slot);
    }
    public override void ClearSlots()
    {
        skill_Fire_Arrow.mySlots.Clear();
    }
    public override bool IsPasif()
    {
        return skill_Fire_Arrow.isPasif;
    }
    public override (int, int) Mana_Cooldown()
    {
        return (skill_Fire_Arrow.mana, skill_Fire_Arrow.coolDown);
    }
    #endregion
}