using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

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

    public int myMoney;
    public int myFreeStat;
    public int myLevel;
    public int myLevelExp;
    public int myLevelExpMax = 10;
    public Inventory myInventory;
    public Equip_Manager_Player equip_Manager_Player;
    public int speedMove;
    public int speedTurn;
    public Vector3 direction;
    private float statArttir = 5;
    private float statArttirNext;
    public List<SkillDurum> skilller = new List<SkillDurum>();
    private void Start()
    {
        for (int e = 0; e < myStats.Count; e++)
        {
            myStats[e].AddStat(0);
            Canvas_Manager.Instance.AddStat(myStats[e]);
        }
        lifeStat.AddStatCore(myStats[0].StatValue);
        manaStat.AddStatCore(myStats[1].StatValue);
        AddLevelExp();
        MyStat("Str").OnStatChanced += Player_OnLifeStatChanced;
        MyStat("Int").OnStatChanced += Player_OnManaStatChanced;
        MyStat("Power").OnStatChanced += Player_OnPowerStatChanced;
        MyStat("Armor").OnStatChanced += Player_OnArmorStatChanced;
        MyStat("Speed").OnStatChanced += Player_OnSpeedStatChanced;
    }
    private void Player_OnLifeStatChanced(object sender, System.EventArgs e)
    {
        Debug.Log(MyStat("Str").StatValue);
        Canvas_Manager.Instance.LifeStatChanced();
    }
    private void Player_OnManaStatChanced(object sender, System.EventArgs e)
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
    public void FreeStatFinish()
    {
        OnFreeStatFinish?.Invoke(this, System.EventArgs.Empty);
    }
    public void FreeStatAdd()
    {
        myFreeStat += 5;
        OnFreeStatAdd?.Invoke(this, System.EventArgs.Empty);
    }
    public float MyLevelPercent()
    {
        return myLevelExp * 1.0f / myLevelExpMax;
    }
    public void AddLevelExp()
    {
        myLevelExp += 5;
        if (myLevelExp >= myLevelExpMax)
        {
            FreeStatAdd();
            myLevel++;
            myLevelExp -= myLevelExpMax;
            myLevelExpMax += 5;
        }
        OnExpChanced?.Invoke(this, new MyExp { myLevelExp = myLevelExp, myLevel = myLevel }) ;
    }
    public float MyLifePercent()
    {
        return lifeStat.StatValue * 1.0f / myStats[0].StatValue;
    }
    public float MyManaPercent()
    {
        return manaStat.StatValue * 1.0f / myStats[1].StatValue;
    }
    private void Update()
    {
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
            AddLevelExp();
        }
        direction = transform.forward;
        // Git İleri-Geri
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
        // Turn Sağ-Sol
        if (canTurn)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (speedTurn * Time.deltaTime), 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - (speedTurn * Time.deltaTime), 0);
            }
        }
    }
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
}