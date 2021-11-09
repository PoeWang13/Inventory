using UnityEngine;

[System.Serializable]
public class Stat
{
    public event System.EventHandler OnStatChanced;
    public Stat(string statName, int myStatCore)
    {
        this.statName = statName;
        this.myStatCore = myStatCore;
    }
    public string statName;
    public int myStatCore;
    private int statCore;
    public int StatValue { get { return statCore; } }
    private int statAdd;
    private int statAddYuzde;
    public void AddStatCore(int add)
    {
        myStatCore += add;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveStatCore(int remove)
    {
        myStatCore -= remove;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void AddStat(int add)
    {
        statAdd += add;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void AddYuzdeStat(int addYuzde)
    {
        statAddYuzde += addYuzde;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveStat(int remove)
    {
        statAdd -= remove;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveYuzdeStat(int removeYuzde)
    {
        statAddYuzde -= removeYuzde;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void ClearStat()
    {
        statAdd = 0;
        statAddYuzde = 0;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void CalculateStatValue()
    {
        statCore = myStatCore + statAdd + (int)(myStatCore * statAddYuzde * 0.01);
    }
}