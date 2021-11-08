using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class SkillDurum
{
    public Skill_Item skill_Item;
    public int skill_Level;

    public SkillDurum(Skill_Item skill_Item, int skill_Level)
    {
        this.skill_Item = skill_Item;
        this.skill_Level = skill_Level;
    }
}
public class Player : Owner
{
    [Header("Script Atamaları")]
    public int myMoney;
    public Inventory myInventory;
    public Equip_Manager_Player equip_Manager_Player;
    public int speedMove;
    public int speedTurn;
    public Vector3 direction;
    public List<SkillDurum> skilller = new List<SkillDurum>();
    private void Update()
    {
        direction = transform.forward;
        // Git İleri-Geri
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-transform.right * speedMove * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.right * speedMove * Time.deltaTime);
            }
        }
        // Turn Sağ-Sol
        if (canTurn)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (speedTurn * Time.deltaTime), 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - (speedTurn * Time.deltaTime), 0);
            }
        }
    }
    public void AddSkill(Skill_Item skill_Item, int skillLevel)
    {
        bool hasSkill = false;
        for (int e = 0; e < skilller.Count && !hasSkill; e++)
        {
            if (skilller[e].skill_Item == skill_Item)
            {
                hasSkill = true;
            }
        }
        if (!hasSkill)
        {
            skill_Item.skill_Object.GetComponent<Skill_Object>().ClearSlots();
            skilller.Add(new SkillDurum(skill_Item, skillLevel));
            Canvas_Manager.Instance.AddSkill(skill_Item, skillLevel);
        }
    }
    public void RemoveSkill(Skill_Item skill_Item)
    {
        bool hasSkill = false;
        for (int e = 0; e < skilller.Count && !hasSkill; e++)
        {
            if (skilller[e].skill_Item == skill_Item)
            {
                hasSkill = true;
                skilller.RemoveAt(e);
            }
        }
    }
}