using UnityEngine;
using System.Collections.Generic;

public class Owner : MonoBehaviour
{
    [HideInInspector] public Stat lifeStat = new Stat("Life", 0);
    [HideInInspector] public Stat manaStat = new Stat("Mana", 0);
    [HideInInspector] public bool canMove;
    [HideInInspector] public bool skillStart;
    public Transform exitPos;
    public List<Stat> myStats = new List<Stat>();

    /// <summary>
    /// Skill bittikten sonra objeyi serbest bırakır.
    /// </summary>
    public void FinishSkill()
    {
        skillStart = false;
        canMove = true;
    }

    /// <summary>
    /// Skill Objesini oluşturur. OBjenin skill yapmasını sağlar
    /// </summary>
    public void CreateSkillObject(Skill_Item mySkill_Item)
    {
        if (!mySkill_Item.IsPasif())
        {
            skillStart = true;
            canMove = false;
        }
        Instantiate(mySkill_Item.skill_Object, transform).GetComponent<Skill_Object>().CreateSkill(this, exitPos.position, transform.forward);
    }
    /// <summary>
    /// Aranan Stat'a sahipsek onu listeden bulup geri dönderir.
    /// </summary>
    public Stat MyStat(string statName)
    {
        for (int e = 0; e < myStats.Count; e++)
        {
            if (myStats[e].statName == statName)
            {
                return myStats[e];
            }
        }
        Canvas_Manager.Instance.UyariYap("<color=red>" + statName + "</color>" + " isimli bir Stat'ınız yoktur.");
        return null;
    }
}