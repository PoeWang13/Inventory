using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Skill_Object : MonoBehaviour
{
    [HideInInspector] public Vector3 exitPos;
    [HideInInspector] public Owner myOwner;
    public void CreateSkill(Owner owner, Vector3 exit, Vector3 direction)
    {
        exitPos = exit;
        myOwner = owner;
        StartSkill(direction);
    }
    public void DestroySkill()
    {
        myOwner.FinishSkill();
        Destroy(gameObject);
    }
    public virtual void AddSkillSlot(Slot slot)
    {
    }
    public virtual void RemoveSkillSlot(Slot slot)
    {
    }
    public virtual void StartSkill(Vector3 direction)
    {

    }
    public virtual void ClearSlots()
    {

    }
    public virtual bool IsPasif()
    {
        return false;
    }
}