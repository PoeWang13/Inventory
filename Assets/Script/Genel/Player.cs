using UnityEngine;
using System.Collections.Generic;

public class MyExp : System.EventArgs
{
    public int myLevel;
    public int myLevelExp;
}
[System.Serializable]
public class SkillDurum
{
    public Skill_Item skill_Item;

    public SkillDurum(Skill_Item skill_Item)
    {
        this.skill_Item = skill_Item;
    }
}
public class Player : Owner
{
    public event System.EventHandler OnFreeStatAdd;
    public event System.EventHandler OnFreeStatFinish;
    public event System.EventHandler<MyExp> OnExpChanced;

    public bool otherPlayer;

    [HideInInspector] public int myFreeStat;
    [SerializeField] private int myLevel;
    [SerializeField] private int myLevelExp;
    private int myLevelExpMax = 10;
    [SerializeField] private int levelExpMaxIncreaceAmount = 5;
    [SerializeField] private int freeStatIncreaceAmount = 5;
    [HideInInspector] public Inventory myInventory;
    [SerializeField] private Equip_Manager_Player equip_Manager_Player;
    [SerializeField] private int speedMove;
    [SerializeField] private int speedTurn;
    private float statArttir = 5;
    private float statArttirNext;
    [SerializeField] private List<SkillDurum> skilller = new List<SkillDurum>();
    private void Start()
    {
        if (otherPlayer)
        {
            return;
        }
        for (int e = 0; e < myStats.Count; e++)
        {
            myStats[e].AddStat(0);
            Canvas_Manager.Instance.AddStat(myStats[e]);
        }
        myInventory = GetComponent<Inventory>();
        lifeStat.AddStatCore(myStats[0].StatValue);
        manaStat.AddStatCore(myStats[1].StatValue);
        AddLevelExp(0);
        MyStat("Str").OnStatChanced += Player_OnStrStatChanced;
        MyStat("Int").OnStatChanced += Player_OnIntStatChanced;
        MyStat("Power").OnStatChanced += Player_OnPowerStatChanced;
        MyStat("Armor").OnStatChanced += Player_OnArmorStatChanced;
        MyStat("Speed").OnStatChanced += Player_OnSpeedStatChanced;
    }

    private void Update()
    {
        if (otherPlayer)
        {
            return;
        }
        statArttirNext += Time.deltaTime;
        if (statArttirNext >= statArttir)
        {
            if (lifeStat.StatValue < myStats[0].StatValue)
            {
                lifeStat.AddStatCore(1);
                statArttirNext = 0;
            }
            if (manaStat.StatValue < myStats[1].StatValue)
            {
                manaStat.AddStatCore(1);
                statArttirNext = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddLevelExp(5);
        }
        // Git Sağ-Sol
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-transform.right * speedMove * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.right * speedMove * Time.deltaTime);
            }
        }
    }
    private void OnMouseUpAsButton()
    {
        if (otherPlayer)
        {
            Canvas_Manager.Instance.OpenOtherEquipPanel(equip_Manager_Player.equip_Items);
        }
    }

    #region Exp
    public int HowManyMyExp()
    {
        return myLevelExp;
    }
    public bool CheckMyExp(int exp)
    {
        if (myLevelExp >= exp)
        {
            return true;
        }
        return false;
    }
    public bool RemoveMyExp(int exp)
    {
        if (myLevelExp >= exp)
        {
            myLevelExp -= exp;
            return true;
        }
        return false;
    }
    public void AddLevelExp(int exp)
    {
        myLevelExp += exp;
        if (myLevelExp >= myLevelExpMax)
        {
            FreeStatAdd();
            myLevel++;
            myLevelExp -= myLevelExpMax;
            myLevelExpMax += levelExpMaxIncreaceAmount;
        }
        OnExpChanced?.Invoke(this, new MyExp { myLevelExp = myLevelExp, myLevel = myLevel });
    }
    #endregion

    #region Stat Chanced
    private void Player_OnStrStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Str").StatValue);
        Canvas_Manager.Instance.LifeStatChanced();
    }
    private void Player_OnIntStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Int").StatValue);
        Canvas_Manager.Instance.ManaStatChanced();
    }
    private void Player_OnPowerStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Power").StatValue);
    }
    private void Player_OnArmorStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Armor").StatValue);
    }
    private void Player_OnSpeedStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Speed").StatValue);
    }
    #endregion

    #region Stat
    public void AddNewStat(string statName, int statCore)
    {
        Stat newStat = new Stat(statName, statCore);
        Canvas_Manager.Instance.AddStat(newStat);
    }
    public void FreeStatFinish()
    {
        OnFreeStatFinish?.Invoke(this, System.EventArgs.Empty);
    }
    public void FreeStatAdd()
    {
        myFreeStat += freeStatIncreaceAmount;
        OnFreeStatAdd?.Invoke(this, System.EventArgs.Empty);
    }
    #endregion

    #region Gosterge Barları
    public float MyLevelPercent()
    {
        return myLevelExp * 1.0f / myLevelExpMax;
    }
    public float MyLifePercent()
    {
        return lifeStat.StatValue * 1.0f / myStats[0].StatValue;
    }
    public float MyManaPercent()
    {
        return manaStat.StatValue * 1.0f / myStats[1].StatValue;
    }
    #endregion

    #region Skill
    /// <summary>
    /// Verilen skill bizde yoksa listemize ekler.
    /// </summary>
    public void AddSkill(Skill_Item skill_Item)
    {
        bool hasSkill = false;
        for (int e = 0; e < skilller.Count && !hasSkill; e++)
        {
            if (skilller[e].skill_Item == skill_Item)
            {
                hasSkill = true;
            }
        }
        if (!hasSkill)
        {
            skill_Item.skill_Object.GetComponent<Skill_Object>().ClearSlots();
            skilller.Add(new SkillDurum(skill_Item));
            Canvas_Manager.Instance.AddSkill(skill_Item);
        }
    }
    /// <summary>
    /// Verilen skill bizde varsa listemizden çıkartır.
    /// </summary>
    public void RemoveSkill(Skill_Item skill_Item)
    {
        bool hasSkill = false;
        for (int e = 0; e < skilller.Count && !hasSkill; e++)
        {
            if (skilller[e].skill_Item == skill_Item)
            {
                hasSkill = true;
                skilller.RemoveAt(e);
            }
        }
    }
    #endregion
}