using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Craft_Table : MonoBehaviour
{
    [Header("Script Atamaları")]
    public string craftListName;
    private bool insidePlayer;
    public KeyCode keyCode = KeyCode.C;
    private GameObject uyari;
    private TextMeshProUGUI openingText;
    public Craft_List_Conteiner craft_List_Conteiner;

    private void Start()
    {
        uyari = transform.GetChild(0).gameObject;
        openingText = uyari.GetComponentInChildren<TextMeshProUGUI>();
        openingText.text = "Open Craft List - <color=blue>" + keyCode.ToString() + "</color> -";
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
            uyari.SetActive(false);
            insidePlayer = false;
            Canvas_Manager.Instance.CloseOpensPanels();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && insidePlayer)
        {
            Canvas_Manager.Instance.OpenCraftList(craft_List_Conteiner, craftListName);
        }
    }
}