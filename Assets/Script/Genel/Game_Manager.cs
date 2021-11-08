using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    public static Game_Manager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public Player player;
    public ItemBox itemBox;

    public void CreateItemBox(Item item, int itemAmount)
    {
       Instantiate(itemBox, player.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f)), Quaternion.identity).ItemBoxDoldur(item, itemAmount);
    }
}