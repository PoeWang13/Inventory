using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Genel/Craft List Conteiner", fileName = "Craft_List_")]
public class Craft_List_Conteiner : ScriptableObject
{
    [Header("Object Atamaları")]
    public List<Craft_Item> craftLists = new List<Craft_Item>();
}