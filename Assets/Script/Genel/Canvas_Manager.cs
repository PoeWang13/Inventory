using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Canvas_Manager : MonoBehaviour
{
    private static Canvas_Manager instance;
    public static Canvas_Manager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region Panel
    public List<GameObject> ortakPaneller = new List<GameObject>();
    public GameObject durumPanel;
    public GameObject inventoryPanel;
    public Bag_Slot bag_Slot;
    public Transform bagSlotParent;
    public GameObject playerEquipPanel;
    public GameObject otherEquipPanel;
    public GameObject skillPanel;
    public GameObject bankPanel;
    public TextMeshProUGUI craftTableName;
    public GameObject craftPanel;
    public TextMeshProUGUI npcTableName;
    public GameObject npcPanel;
    public List<Slot> npcSlots = new List<Slot>();
    public List<Bank_Slot> bankSlots = new List<Bank_Slot>();
    public List<Equip_Slot> playerEquipSlot = new List<Equip_Slot>();
    public List<Slot> otherEquip_Slots = new List<Slot>();
    public Player player;
    public Sprite emptySlotSprite;
    public void OpenDurumPanel()
    {
        OrtakPanelClose();
        durumPanel.SetActive(!durumPanel.activeSelf);
    }
    private void OrtakPanelClose()
    {
        inventoryPanel.SetActive(false);
        for (int e = 0; e < ortakPaneller.Count; e++)
        {
            ortakPaneller[e].SetActive(false);
        }
    }
    public void CloseOpensPanels()
    {
        OrtakPanelClose();
        durumPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }
    public void OpenInventoryPanel()
    {
        OrtakPanelClose();
        durumPanel.SetActive(false);
        inventoryPanel.SetActive(true);
    }
    public void OpenEquipPlayerPanel()
    {
        OpenInventoryPanel();
        playerEquipPanel.SetActive(true);
    }
    public void OpenSkillPanel()
    {
        OpenInventoryPanel();
        skillPanel.SetActive(true);
    }
    public void OpenBankPanel()
    {
        OpenInventoryPanel();
        bankPanel.SetActive(true);
    }
    public void OpenOtherEquipPanel(List<EquipDurum> equipItems, string npcName)
    {
        OpenInventoryPanel();
        otherEquipPanel.SetActive(true);
        npcTableName.text = npcName;

        for (int e = 0; e < otherEquip_Slots.Count; e++)
        {
            otherEquip_Slots[e].SlotBosalt();
        }
        for (int e = 0; e < otherEquip_Slots.Count; e++)
        {
            if (equipItems[e].equip_Item != null)
            {
                otherEquip_Slots[e].SlotDoldur(equipItems[e].equip_Item, 1);
            }
        }
    }
    public void OpenNpcPanel(List<Item> npcItems, List<EquipDurum> equipItems, string npcName)
    {
        npcTableName.text = npcName;
        OpenInventoryPanel();
        npcPanel.SetActive(true);
        otherEquipPanel.SetActive(true);
        for (int e = 0; e < npcSlots.Count; e++)
        {
            npcSlots[e].SlotBosalt();
        }
        for (int e = 0; e < npcItems.Count; e++)
        {
            npcSlots[e].SlotDoldur(npcItems[e], 1);
        }
        for (int e = 0; e < otherEquip_Slots.Count; e++)
        {
            otherEquip_Slots[e].SlotBosalt();
        }
        for (int e = 0; e < otherEquip_Slots.Count; e++)
        {
            if (equipItems[e].equip_Item != null)
            {
                otherEquip_Slots[e].SlotDoldur(equipItems[e].equip_Item, 1);
            }
        }
    }
    #endregion

    #region Carrier Slot
    public Carrier_Slot carrier_Slot;
    public bool IsOpenCarrierSlot()
    {
        return carrier_Slot.gameObject.activeSelf;
    }
    public void OpenCarrierSlot(Slot slot)
    {
        carrier_Slot.transform.position = Input.mousePosition;
        carrier_Slot.gameObject.SetActive(true);
        carrier_Slot.TasinanSlot(slot);
    }
    public void UsedCarrierSlot(Slot slot)
    {
        carrier_Slot.SlotlarDegis(slot);
    }
    public void CarriedSlotBosalt()
    {
        carrier_Slot.CarriedSlotBosalt();
    }
    public Item CarrierSlotItem()
    {
        return carrier_Slot.SlottaHangiItemVar();
    }
    public Slot CarrieedSlot()
    {
        return carrier_Slot.tasinanSlot;
    }
    public void CloseCarrierSlot()
    {
        carrier_Slot.gameObject.SetActive(false);
    }
    #endregion

    #region Craft
    public Craft_Slot craft_Slot;
    public Transform craftSlotParent;
    public void OpenCraftList(Craft_List_Conteiner craft_List_Conteiner, string craftListName)
    {
        craftTableName.text = craftListName;
        OpenInventoryPanel();
        craftPanel.SetActive(true);
        for (int e = 0; e < craftSlotParent.childCount; e++)
        {
            Destroy(craftSlotParent.GetChild(e).gameObject);
        }
        for (int e = 0; e < craft_List_Conteiner.craftLists.Count; e++)
        {
            Craft_Slot craft = Instantiate(craft_Slot, craftSlotParent);
            craft.SlotDoldur(craft_List_Conteiner.craftLists[e], 1);
            craft.myInventory = player.myInventory;
        }
    }
    #endregion

    #region Uyari
    public GameObject uyariPanel;
    public TextMeshProUGUI uyariText;
    public void UyariYap(string uyari)
    {
        StartCoroutine(UyariBaslat(uyari));
    }
    IEnumerator UyariBaslat(string uyari)
    {
        uyariPanel.SetActive(true);
        uyariText.text = uyari;
        yield return new WaitForSeconds(2);
        uyariPanel.SetActive(false);
    }
    #endregion

    #region Skill
    public Transform skillParent;
    public void AddSkill(Skill_Item skill_Item)
    {
        Instantiate(skill_Item.skillUI, skillParent).SetSkillUI();
        if (skill_Item.IsPasif())
        {
            skill_Item.UseItem(null, player.myInventory);
        }
    }
    #endregion

    #region Stat
    public StatUI statPrefab;
    public Transform statParent;
    public Image lifeImage;
    public Image manaImage;
    public void AddStat(Stat stat)
    {
        Instantiate(statPrefab, statParent).SetStatUI(stat, player);
    }
    public void LifeStatChanced()
    {
        lifeImage.fillAmount = player.MyLifePercent();
    }
    private void Player_OnLifeStatChanced(object sender, System.EventArgs e)
    {
        LifeStatChanced();
    }
    public void ManaStatChanced()
    {
        manaImage.fillAmount = player.MyManaPercent();
    }
    private void Player_OnManaStatChanced(object sender, System.EventArgs e)
    {
        ManaStatChanced();
    }
    #endregion

    #region Exp
    public TextMeshProUGUI levelExp;
    public TextMeshProUGUI levelPercent;
    public Image levelImage;
    private void Player_OnExpChanced(object sender, MyExp myExp)
    {
        levelExp.text = "My Exp : " + myExp.myLevelExp.ToString();
        float lvlPercent = player.MyLevelPercent();
        levelPercent.text = "My Level : " + myExp.myLevel + " - " + " % " + (lvlPercent * 100).ToString("F");
        levelImage.fillAmount = lvlPercent;
    }
    private void Start()
    {
        player.OnExpChanced += Player_OnExpChanced;
        player.lifeStat.OnStatChanced += Player_OnLifeStatChanced;
        player.manaStat.OnStatChanced += Player_OnManaStatChanced;
    }
    #endregion
}