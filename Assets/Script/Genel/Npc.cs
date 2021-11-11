using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Npc : MonoBehaviour
{
    [Header("Script Atamaları")]
    private bool insidePlayer;
    private GameObject uyari;
    private TextMeshProUGUI openingText;
    private Equip_Manager equip_Manager;
    [SerializeField] private KeyCode keyCode = KeyCode.N;
    [SerializeField] private List<Item> npcInventoryItems = new List<Item>();

    private void Start()
    {
        uyari = transform.GetChild(0).gameObject;
        openingText = uyari.GetComponentInChildren<TextMeshProUGUI>();
        equip_Manager = uyari.GetComponent<Equip_Manager>();
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
            Canvas_Manager.Instance.OpenNpcPanel(npcInventoryItems, equip_Manager.equip_Items, gameObject.name);
        }
    }
}