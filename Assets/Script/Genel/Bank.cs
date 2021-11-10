using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [Header("Script Atamaları")]
    public bool insidePlayer;
    public KeyCode keyCode = KeyCode.B;
    private GameObject uyari;
    private TextMeshProUGUI openingText;

    private void Start()
    {
        uyari = transform.GetChild(0).gameObject;
        openingText = uyari.GetComponentInChildren<TextMeshProUGUI>();
        openingText.text = "Open Bank - <color=green>" + keyCode.ToString() + "</color> -";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uyari.SetActive(true);
            insidePlayer = true;
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
            Canvas_Manager.Instance.OpenBankPanel();
        }
    }
}