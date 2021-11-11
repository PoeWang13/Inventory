using UnityEngine;
using TMPro;
public class ItemBox : PoolObje
{
    [SerializeField] private Item item;
    [SerializeField] private int itemAmount;
    [SerializeField] private KeyCode keyCode = KeyCode.B;
    private bool insidePlayer;
    private Inventory playerInventory;
    private GameObject uyari;
    private TextMeshProUGUI openingText;

    public void ItemBoxDoldur(Item item, int itemAmount)
    {
        this.item = item;
        this.itemAmount = itemAmount;
    }
    private void Start()
    {
        uyari = transform.GetChild(0).gameObject;
        openingText = uyari.GetComponentInChildren<TextMeshProUGUI>();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetComponent<Inventory>();
        openingText.text = "Collect - <color=blue>" + keyCode.ToString() + "</color> -";
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
            uyari.SetActive(false);
            insidePlayer = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && insidePlayer)
        {
            itemAmount = playerInventory.ItemEkle(item, itemAmount).Item2;
            if (itemAmount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}