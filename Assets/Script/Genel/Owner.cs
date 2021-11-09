using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Owner : MonoBehaviour
{
    public Stat lifeStat = new Stat("Life", 0);
    public Stat manaStat = new Stat("Mana", 0);
    public bool canMove;
    public bool canTurn;
    public bool skillStart;
    public Transform exitPos;
    public List<Stat> myStats = new List<Stat>();
    public void FinishSkill()
    {
        skillStart = false;
        canMove = true;
        canTurn = true;
    }
    public void CreateSkillObject(Skill_Item mySkill_Item)
    {
        skillStart = true;
        canMove = false;
        canTurn = false;
        Instantiate(mySkill_Item.skill_Object, transform).GetComponent<Skill_Object>().CreateSkill(this, exitPos.position, transform.forward);
    }
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