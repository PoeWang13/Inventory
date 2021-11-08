using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Player player;
    public Item item;
    public int itemAmount;
    public bool insidePlayer;
    public KeyCode keyCode = KeyCode.B;

    public void ItemBoxDoldur(Item item, int itemAmount)
    {
        this.item = item;
        this.itemAmount = itemAmount;
    }
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
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && insidePlayer)
        {
            itemAmount = player.GetComponent<Inventory>().ItemEkle(item, itemAmount).Item2;
            if (itemAmount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}