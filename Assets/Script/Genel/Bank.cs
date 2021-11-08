using UnityEngine;

public class Bank : MonoBehaviour
{
    [Header("Script Atamaları")]
    public bool insidePlayer;
    public KeyCode keyCode = KeyCode.B;

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
            Canvas_Manager.Instance.OpenBankPanel();
        }
    }
}