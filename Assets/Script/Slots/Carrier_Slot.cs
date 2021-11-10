using UnityEngine;

public class Carrier_Slot : Slot
{
    public Slot tasinanSlot;
    [SerializeField] private Vector3 offSet = new Vector3(-10, 10, 0);
    [SerializeField] private Canvas popupCanvas;
    [SerializeField] private int padding = 10;
    private Vector3 newPos;
    public void TasinanSlot(Slot tasinan)
    {
        tasinanSlot = tasinan;
        SlotDoldur(tasinanSlot.item, tasinanSlot.itemAmount);
    }
    public void CarriedSlotBosalt()
    {
        tasinanSlot.SlotBosalt();
    }
    public void SlotlarDegis(Slot yeni)
    {
        if (yeni.SlotDolumu())
        {
            tasinanSlot.SlotDoldur(yeni.item, yeni.itemAmount);
        }
        else
        {
            if (!(tasinanSlot is Skill_Slot))
            {
                tasinanSlot.SlotBosalt();
            }
        }
        if (item is Skill_Item)
        {
            (item as Skill_Item).skill_Object.GetComponent<Skill_Object>().AddSkillSlot(yeni);
            if (!(tasinanSlot is Skill_Slot))
            {
                (item as Skill_Item).skill_Object.GetComponent<Skill_Object>().RemoveSkillSlot(tasinanSlot);
            }
        }
        yeni.SlotDoldur(item, itemAmount);
        CarrierBosalt();
    }
    private void Update()
    {
        newPos = Input.mousePosition + offSet;
        newPos.z = 0f;
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - 100 * popupCanvas.scaleFactor) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + 100 * popupCanvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        transform.position = newPos;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CarrierBosalt();
        }
    }
    private void CarrierBosalt()
    {
        SlotBosalt();
        gameObject.SetActive(false);
    }
}