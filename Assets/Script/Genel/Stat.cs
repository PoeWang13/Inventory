using UnityEngine;

[System.Serializable]
public class Stat
{
    public Stat(string statName, int myStatCore)
    {
        this.statName = statName;
        this.myStatCore = myStatCore;
    }
    public string statName;
    public int myStatCore;
    private int statCore;
    public int StatValue { 
        get {
            if (isDirty)
            {
                isDirty = false;
                CalculateStatValue();
            }
            return statCore; } }
    private bool isDirty = true;
    private int statAdd;
    private int statAddYuzde;
    public void AddStat(int add)
    {
        statAdd += add;
        isDirty = true;
    }
    public void AddYuzdeStat(int addYuzde)
    {
        statAddYuzde += addYuzde;
        isDirty = true;
    }
    public void RemoveStat(int add)
    {
        statAdd -= add;
        isDirty = true;
    }
    public void RemoveYuzdeStat(int addYuzde)
    {
        statAddYuzde -= addYuzde;
        isDirty = true;
    }
    public void ClearStat()
    {
        statAdd = 0;
        statAddYuzde = 0;
        isDirty = true;
    }
    public void CalculateStatValue()
    {
        statCore = myStatCore + statAdd + (int)(myStatCore * statAddYuzde * 0.01);
    }
}