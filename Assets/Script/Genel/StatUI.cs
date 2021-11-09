using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StatUI : MonoBehaviour
{
    public Player player;
    public Stat myStat;
    public Button upgradeButton;
    public TextMeshProUGUI statText;

    public void SetStatUI(Stat stat, Player pl)
    {
        myStat = stat;
        player = pl;
        statText.text = myStat.statName + " : " + myStat.StatValue.ToString();
        myStat.OnStatChanced += Player_OnStatChanced;
        player.OnFreeStatAdd += Player_OnFreeStatAdd;
        player.OnFreeStatFinish += Player_OnFreeStatFinish;
    }
    public void UpgradeStat()
    {
        if (player.myFreeStat > 0)
        {
            myStat.AddStatCore(1);
            statText.text = myStat.statName + " : " + myStat.StatValue.ToString();
            player.myFreeStat--;
            if (player.myFreeStat == 0)
            {
                player.FreeStatFinish();
            }
        }
    }
    private void Player_OnStatChanced(object sender, System.EventArgs e)
    {
        statText.text = myStat.statName + " : " + myStat.StatValue.ToString();
    }
    private void Player_OnFreeStatAdd(object sender, System.EventArgs e)
    {
        upgradeButton.gameObject.SetActive(true);
    }
    private void Player_OnFreeStatFinish(object sender, System.EventArgs e)
    {
        upgradeButton.gameObject.SetActive(false);
    }
}