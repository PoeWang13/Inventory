using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Skill
{
    [Header("Script Atamaları")]
    public bool isPasif;
    public int mana;
    public int coolDown;
    [HideInInspector] public float coolDownNext;
    [HideInInspector] public List<Slot> mySlots = new List<Slot>();
}