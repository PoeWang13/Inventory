using UnityEngine;

[System.Serializable]
public class EquipDurum
{
    public Equip_Item equip_Item;
    public Body_Part bodyPart;
}
public class Equip_Manager : MonoBehaviour
{
    private Owner myOwner;
    private void Start()
    {
        myOwner = GetComponent<Owner>();
    }
    /// <summary>
    /// Elbiseyi giyince elbisedeki statları giyer.
    /// </summary>
    public void Equip(Equip_Item equip_Item)
    {
        for (int e = 0; e < equip_Item.myStats.Count; e++)
        {
            bool findStat = false;
            for (int h = 0; h < myOwner.myStats.Count && !findStat; h++)
            {
                if (equip_Item.myStats[e].stat.statName == myOwner.myStats[h].statName)
                {
                    findStat = true;
                    if (equip_Item.myStats[e].isPercent)
                    {
                        myOwner.myStats[h].AddYuzdeStat(equip_Item.myStats[e].stat.myStatCore);
                    }
                    else
                    {
                        myOwner.myStats[h].AddStat(equip_Item.myStats[e].stat.myStatCore);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Elbiseyi çıkartınca elbisedeki statları çıkartır.
    /// </summary>
    public void UnEquip(Equip_Item equip_Item)
    {
        for (int e = 0; e < equip_Item.myStats.Count; e++)
        {
            bool findStat = false;
            for (int h = 0; h < myOwner.myStats.Count && !findStat; h++)
            {
                if (equip_Item.myStats[e].stat.statName == myOwner.myStats[h].statName)
                {
                    findStat = true;
                    if (equip_Item.myStats[e].isPercent)
                    {
                        myOwner.myStats[h].RemoveYuzdeStat(equip_Item.myStats[e].stat.myStatCore);
                    }
                    else
                    {
                        myOwner.myStats[h].RemoveStat(equip_Item.myStats[e].stat.myStatCore);
                    }
                }
            }
        }
    }
}