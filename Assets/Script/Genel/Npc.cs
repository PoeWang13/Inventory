using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Npc : MonoBehaviour
{
    [Header("Script Atamaları")]
    public string npcName;
    public Player player;
    public bool insidePlayer;
    public Equip_Manager_Npc equip_Manager_Npc;
    public KeyCode keyCode = KeyCode.N;
    public List<EquipDurum> equip_Items = new List<EquipDurum>();
    public List<Stat> myStats = new List<Stat>();
    public List<Item> npcInventoryItems = new List<Item>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidePlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidePlayer = false;
            Canvas_Manager.Instance.CloseOpensPanels();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && insidePlayer)
        {
            Canvas_Manager.Instance.OpenNpcPanel(npcInventoryItems, equip_Items, npcName);
        }
    }
}