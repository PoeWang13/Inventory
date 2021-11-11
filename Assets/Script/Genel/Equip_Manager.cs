using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EquipDurum
{
    public Equip_Item equip_Item;
    public Body_Part bodyPart;
}
public class Equip_Manager : MonoBehaviour
{
    private Owner myOwner;
    private int myDressSetNumber = -1;
    private int myWeaponSetNumber = -1;
    private int myAccessuarsSetNumber = -1;
    private int myCompleteSetNumber = -1;
    [SerializeField] private EquipSetStatHolder equipSetStatHolder;
    public List<EquipDurum> equip_Items = new List<EquipDurum>();
    public virtual void Start()
    {
        myOwner = GetComponent<Owner>();
    }
    /// <summary>
    /// Elbiseyi giyince elbisedeki statları giyer.
    /// </summary>
    public void Equip(Equip_Item equip_Item)
    {
        for (int e = 0; e < equip_Item.myEquipStats.Count; e++)
        {
            bool findStat = false;
            for (int h = 0; h < myOwner.myStats.Count && !findStat; h++)
            {
                if (equip_Item.myEquipStats[e].stat.statName == myOwner.myStats[h].statName)
                {
                    findStat = true;
                    if (equip_Item.myEquipStats[e].isPercent)
                    {
                        myOwner.myStats[h].AddYuzdeStat(equip_Item.myEquipStats[e].stat.myStatCore);
                    }
                    else
                    {
                        myOwner.myStats[h].AddStat(equip_Item.myEquipStats[e].stat.myStatCore);
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
        for (int e = 0; e < equip_Item.myEquipStats.Count; e++)
        {
            bool findStat = false;
            for (int h = 0; h < myOwner.myStats.Count && !findStat; h++)
            {
                if (equip_Item.myEquipStats[e].stat.statName == myOwner.myStats[h].statName)
                {
                    findStat = true;
                    if (equip_Item.myEquipStats[e].isPercent)
                    {
                        myOwner.myStats[h].RemoveYuzdeStat(equip_Item.myEquipStats[e].stat.myStatCore);
                    }
                    else
                    {
                        myOwner.myStats[h].RemoveStat(equip_Item.myEquipStats[e].stat.myStatCore);
                    }
                }
            }
        }
    }
    public virtual void HaveSetEquip(int setPartNumber, bool isSet, Skill_Item skill_Item)
    {

    }
    public void ControlSet()
    {
        (bool, int) DressSetDurumu = DressSetGiyiyormu();
        if (myDressSetNumber == -1)
        {
            // Dress Set giymiyordu ama su anda giyiyor.
            if (DressSetDurumu.Item1)
            {
                SetEquipGrup setEquipDressGrup = equipSetStatHolder.ReturnSetStats(DressSetDurumu.Item2).myDressSetStats[0];
                SetStatDuzelt(setEquipDressGrup.mySetStats, true);
                myDressSetNumber = DressSetDurumu.Item2;
                if (setEquipDressGrup.skill_Item != null)
                {
                    HaveSetEquip(0, true, setEquipDressGrup.skill_Item);
                }
            }
        }
        else
        {
            // Dress Set giyiyordu ama su anda giymiyor.
            if (!DressSetDurumu.Item1)
            {
                SetEquipGrup setEquipDressGrup = equipSetStatHolder.ReturnSetStats(myDressSetNumber).myDressSetStats[0];
                SetStatDuzelt(setEquipDressGrup.mySetStats, false);
                if (setEquipDressGrup.skill_Item != null)
                {
                    HaveSetEquip(0, false, setEquipDressGrup.skill_Item);
                }
                myDressSetNumber = -1;
            }
        }
        (bool, int) WeaponSetDurumu = WeaponSetGiyiyormu();
        if (myWeaponSetNumber == -1)
        {
            // Weapon Set giymiyordu ama su anda giyiyor.
            if (WeaponSetDurumu.Item1)
            {
                SetEquipGrup setEquipWeaponGrup = equipSetStatHolder.ReturnSetStats(WeaponSetDurumu.Item2).myWeaponSetStats[0];
                SetStatDuzelt(setEquipWeaponGrup.mySetStats, true);
                myWeaponSetNumber = WeaponSetDurumu.Item2;
                if (setEquipWeaponGrup.skill_Item != null)
                {
                    HaveSetEquip(1, true, setEquipWeaponGrup.skill_Item);
                }
            }
        }
        else
        {
            // Weapon Set giyiyordu ama su anda giymiyor.
            if (!WeaponSetDurumu.Item1)
            {
                SetEquipGrup setEquipWeaponGrup = equipSetStatHolder.ReturnSetStats(myWeaponSetNumber).myWeaponSetStats[0];
                SetStatDuzelt(setEquipWeaponGrup.mySetStats, false);
                if (setEquipWeaponGrup.skill_Item != null)
                {
                    HaveSetEquip(1, false, setEquipWeaponGrup.skill_Item);
                }
                myWeaponSetNumber = -1;
            }
        }
        (bool, int) AccessuarsSetDurumu = AccessuarsSetGiyiyormu();
        if (myAccessuarsSetNumber == -1)
        {
            // Accessuars Set giymiyordu ama su anda giyiyor.
            if (AccessuarsSetDurumu.Item1)
            {
                SetEquipGrup setEquipAccessuarsGrup = equipSetStatHolder.ReturnSetStats(AccessuarsSetDurumu.Item2).myAccessuarsSetStats[0];
                SetStatDuzelt(setEquipAccessuarsGrup.mySetStats, true);
                myAccessuarsSetNumber = AccessuarsSetDurumu.Item2;
                if (setEquipAccessuarsGrup.skill_Item != null)
                {
                    HaveSetEquip(2, true, setEquipAccessuarsGrup.skill_Item);
                }
            }
        }
        else
        {
            // Accessuars Set giyiyordu ama su anda giymiyor.
            if (!AccessuarsSetDurumu.Item1)
            {
                SetEquipGrup setEquipAccessuarsGrup = equipSetStatHolder.ReturnSetStats(myAccessuarsSetNumber).myAccessuarsSetStats[0];
                SetStatDuzelt(setEquipAccessuarsGrup.mySetStats, false);
                if (setEquipAccessuarsGrup.skill_Item != null)
                {
                    HaveSetEquip(2, false, setEquipAccessuarsGrup.skill_Item);
                }
                myAccessuarsSetNumber = -1;
            }
        }
        (bool, int) CompleteSetDurumu = CompleteSetGiyiyormu();
        if (myCompleteSetNumber == -1)
        {
            // Complete Set giymiyordu ama su anda giyiyor.
            if (CompleteSetDurumu.Item1)
            {
                SetEquipGrup setEquipCompleteGrup = equipSetStatHolder.ReturnSetStats(CompleteSetDurumu.Item2).myCompleteSetStats[0];
                SetStatDuzelt(setEquipCompleteGrup.mySetStats, true);
                myCompleteSetNumber = CompleteSetDurumu.Item2;
                if (setEquipCompleteGrup.skill_Item != null)
                {
                    HaveSetEquip(3, true, setEquipCompleteGrup.skill_Item);
                }
            }
        }
        else
        {
            // Complete Set giyiyordu ama su anda giymiyor.
            if (!CompleteSetDurumu.Item1)
            {
                SetEquipGrup setEquipCompleteGrup = equipSetStatHolder.ReturnSetStats(myCompleteSetNumber).myCompleteSetStats[0];
                SetStatDuzelt(setEquipCompleteGrup.mySetStats, false);
                if (setEquipCompleteGrup.skill_Item != null)
                {
                    HaveSetEquip(3, false, setEquipCompleteGrup.skill_Item);
                }
                myCompleteSetNumber = -1;
            }
        }
    }
    /// <summary>
    /// Bool : Set giyiyor mu, Int : Kaç numaralı seti giyiyor.
    /// </summary>
    private (bool, int) DressSetGiyiyormu()
    {
        int setNumber = -1;
        if (equip_Items[0].equip_Item == null)
        {
            return (false, -1);
        }
        setNumber = equip_Items[0].equip_Item.setNumber;
        for (int e = 1; e < 5; e++)
        {
            if (equip_Items[e].equip_Item == null || equip_Items[e].equip_Item.setNumber != setNumber)
            {
                return (false, -1);
            }
        }
        return (true, setNumber);
    }
    /// <summary>
    /// Bool : Set giyiyor mu, Int : Kaç numaralı seti giyiyor.
    /// </summary>
    private (bool, int) WeaponSetGiyiyormu()
    {
        if (equip_Items[5].equip_Item == null)
        {
            return (false, -1);
        }
        else if (equip_Items[6].equip_Item == null)
        {
            return (false, -1);
        }
        else
        {
            return (true, equip_Items[5].equip_Item.setNumber);
        }
    }
    /// <summary>
    /// Bool : Set giyiyor mu, Int : Kaç numaralı seti giyiyor.
    /// </summary>
    private (bool, int) AccessuarsSetGiyiyormu()
    {
        int setNumber = -1;
        if (equip_Items[7].equip_Item == null)
        {
            return (false, -1);
        }
        setNumber = equip_Items[7].equip_Item.setNumber;
        for (int e = 8; e < equip_Items.Count; e++)
        {
            if (equip_Items[e].equip_Item == null || equip_Items[e].equip_Item.setNumber != setNumber)
            {
                return (false, -1);
            }
        }
        return (true, setNumber);
    }
    /// <summary>
    /// Bool : Set giyiyor mu, Int : Kaç numaralı seti giyiyor.
    /// </summary>
    private (bool, int) CompleteSetGiyiyormu()
    {
        int setNumber = -1;
        if (equip_Items[0].equip_Item == null)
        {
            return (false, -1);
        }
        setNumber = equip_Items[0].equip_Item.setNumber;
        for (int e = 1; e < equip_Items.Count; e++)
        {
            if (equip_Items[e].equip_Item == null || equip_Items[e].equip_Item.setNumber != setNumber)
            {
                return (false, -1);
            }
        }
        return (true, setNumber);
    }
    private void SetStatDuzelt(List<StatDurum> setStats, bool ekle)
    {
        for (int e = 0; e < setStats.Count; e++)
        {
            bool buldum = false;
            for (int h = 0; h < myOwner.myStats.Count && !buldum; h++)
            {
                if (myOwner.myStats[h].statName == setStats[e].stat.statName)
                {
                    buldum = true;
                    if (ekle)
                    {
                        if (setStats[e].isPercent)
                        {
                            myOwner.myStats[h].AddYuzdeStat(setStats[e].stat.myStatCore);
                        }
                        else
                        {
                            myOwner.myStats[h].AddStat(setStats[e].stat.myStatCore);
                        }
                    }
                    else
                    {
                        if (setStats[e].isPercent)
                        {
                            myOwner.myStats[h].RemoveYuzdeStat(setStats[e].stat.myStatCore);
                        }
                        else
                        {
                            myOwner.myStats[h].RemoveStat(setStats[e].stat.myStatCore);
                        }
                    }
                }
            }
        }
    }
}