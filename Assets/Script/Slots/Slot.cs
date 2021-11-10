using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Inventory myInventory;
    public Button slotButton;
    public Image itemImage;
    public Image usedImage;
    public Image coolDownImage;
    public GameObject kilitImage;
    public Transform effectParent;

    /*[HideInInspector]*/ public Item item;
    /*[HideInInspector]*/ public int itemAmount;
    public TextMeshProUGUI itemAmountText;
    private bool canUseSlot;

    #region Skill
    public void UseCooldDownImage(float coolDown)
    {
        coolDownImage.fillAmount = coolDown;
    }
    #endregion

    #region Slot Use
    public void SlotCanUsed(bool canUsed)
    {
        canUseSlot = canUsed;
        kilitImage.SetActive(canUsed);
    }
    public void SlotHasEffect(GameObject effect)
    {
        Instantiate(effect, effectParent);
    }
    #endregion

    #region Slot Item
    public void SlotDoldur(Item item, int amount)
    {
        this.item = item;
        itemAmount = amount;
        itemImage.sprite = item.myIcon;
        itemAmountText.text = amount.ToString();
        item.HasEffect(this);
    }
    public void SlotBosalt()
    {
        itemAmount = 0;
        itemAmountText.text = "";
        itemImage.sprite = Canvas_Manager.Instance.emptySlotSprite;
        if (effectParent.childCount != 0)
        {
            Destroy(effectParent.GetChild(0).gameObject);
        }
        item = null;
        coolDownImage.fillAmount = 0;
        usedImage.gameObject.SetActive(false);
    }
    /// <summary>
    /// Slotta 1'den fazla item kullanılır.Return kullanılan item sayısını verir.
    /// </summary>
    public int SlotAdetItemKullan(int amount)
    {
        if (item != null)
        {
            if (itemAmount > amount)
            {
                itemAmount -= amount;
                itemAmountText.text = itemAmount.ToString();
                return amount;
            }
            else
            {
                SlotBosalt();
                return itemAmount;
            }
        }
        return 0;
    }
    public void SlotItemKullan()
    {
        itemAmount--;
        if (itemAmount == 0)
        {
            SlotBosalt();
        }
    }
    /// <summary>
    /// Dönen rakam kadar item eklenmemiş demektir.
    /// </summary>
    public int SlotEksikAmountDoldur(int amount)
    {
        if (amount >= item.maxAmount - itemAmount)
        {
            amount = amount - (item.maxAmount - itemAmount);
            itemAmount = item.maxAmount;
            itemAmountText.text = itemAmount.ToString();
            return amount;
        }
        else
        {
            itemAmount += amount;
            itemAmountText.text = itemAmount.ToString();
            return 0;
        }
    }
    /// <summary>
    /// Slotta item varsa true, item yoksa false döner
    /// </summary>
    public bool SlotDolumu()
    {
        return item != null;
    }
    public Item SlottaHangiItemVar()
    {
        return item;
    }
    public int SlottaKacAdetItemVar()
    {
        return itemAmount;
    }
    /// <summary>
    /// Slottaki itemin maxAmount ile itemAmount farkını verir.
    /// </summary>
    public int SlottaKacAdetEksikItemVar()
    {
        return item.maxAmount - itemAmount;
    }
    public void SlotButtonInterac(bool interac)
    {
        slotButton.interactable = interac;
    }
    #endregion

    #region Clickler
    public virtual void LeftClick()
    {

    }
    public virtual void MiddleClick()
    {

    }
    public virtual void RightClick()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                LeftClick();
            }
            else if (eventData.button == PointerEventData.InputButton.Middle)
            {
                MiddleClick();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                RightClick();
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Tool_Manager.Instance.OpenTool(this);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tool_Manager.Instance.CloseTool();
    } 
    #endregion
}