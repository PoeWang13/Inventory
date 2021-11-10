using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Npc : MonoBehaviour
{
    [Header("Script Atamaları")]
    private bool insidePlayer;
    public KeyCode keyCode = KeyCode.N;
    private GameObject uyari;
    private TextMeshProUGUI openingText;
    public List<EquipDurum> equip_Items = new List<EquipDurum>();
    public List<Stat> myStats = new List<Stat>();
    public List<Item> npcInventoryItems = new List<Item>();

    private void Start()
    {
        uyari = transform.GetChild(0).gameObject;
        openingText = uyari.GetComponentInChildren<TextMeshProUGUI>();
        openingText.text = "Talking - <color=red>" + keyCode.ToString() + "</color> -";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidePlayer = true;
            uyari.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidePlayer = false;
            uyari.SetActive(false);
            Canvas_Manager.Instance.CloseOpensPanels();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && insidePlayer)
        {
            Canvas_Manager.Instance.OpenNpcPanel(npcInventoryItems, equip_Items, gameObject.name);
        }
    }
}