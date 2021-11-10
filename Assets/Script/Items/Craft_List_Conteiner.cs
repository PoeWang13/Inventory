using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Item/Container/Craft List", fileName = "Craft_List_")]
public class Craft_List_Conteiner : ScriptableObject
{
    [Header("Object Atamaları")]
    public List<Craft_Item> craftLists = new List<Craft_Item>();
}