using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Skill
{
    [Header("Script Atamaları")]
    public int coolDown;
    public float coolDownNext;
    public List<Slot> mySlots = new List<Slot>();
}