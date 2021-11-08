using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Craft_Table : MonoBehaviour
{
    [Header("Script Atamaları")]
    public string craftListName;
    public Player player;
    public bool insidePlayer;
    public KeyCode keyCode = KeyCode.C;
    public Craft_List_Conteiner craft_List_Conteiner;

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
            Canvas_Manager.Instance.OpenCraftList(craft_List_Conteiner, craftListName);
        }
    }
}