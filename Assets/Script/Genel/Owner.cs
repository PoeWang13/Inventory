using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Owner : MonoBehaviour
{
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
}