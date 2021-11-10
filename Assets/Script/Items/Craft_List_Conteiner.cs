using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Item/Container/Craft List", fileName = "Craft_List_")]
public class Craft_List_Conteiner : ScriptableObject
{
    [Header("Yapılacak itemler")]
    [SerializeField] private List<Craft_Item> craftLists = new List<Craft_Item>();
    public bool HasCratItem(Craft_Item craft_Item)
    {
        if (craftLists.Contains(craft_Item))
        {
            return true;
        }
        return false;
    }
    public void AddCratItem(Craft_Item craft_Item)
    {
        craftLists.Add(craft_Item);
    }
    public int HowManyCratItem()
    {
        return craftLists.Count;
    }
    public Craft_Item ReturnCratItem(int craft_Item)
    {
        return craftLists[craft_Item];
    }
}