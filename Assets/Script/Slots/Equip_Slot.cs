using UnityEngine;

public class Equip_Slot : Slot
{
    [SerializeField] private Canvas_Manager canvas_Manager;
    [SerializeField] private Equip_Manager_Player equip_Manager_Player;
    public Body_Part bodyPart;
    /// equip slot       : Sol tık - çıkart + orta tık - yere at + sağ tık - kullan
    public override void LeftClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (canvas_Manager.IsOpenCarrierSlot())
        {
            if (canvas_Manager.CarrierSlotItem() is Equip_Item)
            {
                Equip_Item equip_Item = canvas_Manager.CarrierSlotItem() as Equip_Item;
                if (bodyPart == equip_Item.bodyPart)
                {
                    if (equip_Item.IsCiftKol())
                    {
                        int yerlerDolumu = 0;
                        if (SlotDolumu())
                        {
                            yerlerDolumu++;
                        }
                        if (equip_Manager_Player.equipSlot[6].SlotDolumu())
                        {
                            yerlerDolumu++;
                        }
                        if (yerlerDolumu == 0)
                        {
                            equip_Manager_Player.Equip(equip_Item);
                            canvas_Manager.UsedCarrierSlot(this);
                            equip_Manager_Player.equip_Items[6].equip_Item = equip_Item;
                            equip_Manager_Player.ControlSet();
                        }
                        else if (yerlerDolumu == 1)
                        {
                            Equip_Item equip_Item1 = item as Equip_Item;
                            Equip_Item equip_Item2 = equip_Manager_Player.equipSlot[6].item as Equip_Item;
                            if (equip_Item1 != null)
                            {
                                equip_Manager_Player.UnEquip(equip_Item1);
                                canvas_Manager.CarrieedSlot().SlotDoldur(equip_Item1, 1);
                            }
                            else
                            {
                                equip_Manager_Player.UnEquip(equip_Item2);
                                equip_Manager_Player.equipSlot[6].SlotBosalt();
                                canvas_Manager.CarrieedSlot().SlotDoldur(equip_Item, 1);
                                equip_Manager_Player.equip_Items[6].equip_Item = null;
                            }
                            SlotDoldur(equip_Item, 1);
                            equip_Manager_Player.Equip(equip_Item);
                            equip_Manager_Player.equip_Items[5].equip_Item = equip_Item;
                            equip_Manager_Player.ControlSet();
                        }
                        else if (yerlerDolumu == 2)
                        {
                            if (canvas_Manager.player.myInventory.BosSlotVar().Item2 > 1)
                            {
                                Equip_Item equip_Item1 = item as Equip_Item;
                                Equip_Item equip_Item2 = equip_Manager_Player.equipSlot[6].item as Equip_Item;
                                equip_Manager_Player.UnEquip(equip_Item1);
                                equip_Manager_Player.UnEquip(equip_Item2);
                                equip_Manager_Player.equipSlot[6].SlotBosalt();
                                canvas_Manager.CarrieedSlot().SlotDoldur(equip_Item1, 1);
                                canvas_Manager.player.myInventory.ItemEkle(equip_Item2, 1);
                                SlotDoldur(equip_Item, 1);
                                equip_Manager_Player.Equip(equip_Item);
                                equip_Manager_Player.equip_Items[5].equip_Item = equip_Item;
                                equip_Manager_Player.equip_Items[6].equip_Item = null;
                                equip_Manager_Player.ControlSet();
                            }
                        }
                    }
                    else if (equip_Manager_Player.EquipSlotNo(bodyPart) == 6)
                    {
                        if (equip_Manager_Player.equipSlot[5].SlotDolumu() && (equip_Manager_Player.equipSlot[5].item as Equip_Item).IsCiftKol())
                        {
                            Equip_Item equip_Item1 = equip_Manager_Player.equipSlot[5].item as Equip_Item;
                            equip_Manager_Player.UnEquip(equip_Item1);
                            equip_Manager_Player.equip_Items[5].equip_Item = null;
                            canvas_Manager.CarrieedSlot().SlotDoldur(equip_Item1, 1);
                            equip_Manager_Player.equipSlot[5].SlotBosalt();
                        }
                        else if (SlotDolumu())
                        {
                            Equip_Item equip_Item2 = item as Equip_Item;
                            equip_Manager_Player.UnEquip(equip_Item2);
                            equip_Manager_Player.equip_Items[5].equip_Item = null;
                            canvas_Manager.CarrieedSlot().SlotDoldur(equip_Item2, 1);
                        }
                        canvas_Manager.CarrieedSlot().SlotBosalt();
                        equip_Manager_Player.Equip(equip_Item);
                        SlotDoldur(equip_Item, 1);
                        equip_Manager_Player.equip_Items[6].equip_Item = equip_Item;
                        equip_Manager_Player.ControlSet();
                    }
                    else
                    {
                        if (SlotDolumu())
                        {
                            equip_Manager_Player.UnEquip(item as Equip_Item);
                            canvas_Manager.CarrieedSlot().SlotDoldur(item, 1);
                        }
                        else
                        {
                            canvas_Manager.CarrieedSlot().SlotBosalt();
                        }
                        SlotDoldur(equip_Item, 1);
                        equip_Manager_Player.Equip(equip_Item);
                        equip_Manager_Player.EquipItemsGiy(bodyPart, equip_Item);
                        equip_Manager_Player.ControlSet();
                    }
                }
            }
            canvas_Manager.CloseCarrierSlot();
        }
        else
        {
            if (SlotDolumu())
            {
                if (canvas_Manager.player.myInventory.BosSlotVar().Item1)
                {
                    canvas_Manager.player.myInventory.ItemEkle(item, 1);
                    equip_Manager_Player.UnEquip(item as Equip_Item);
                    SlotBosalt();
                    equip_Manager_Player.EquipItemsGiy(bodyPart, null);
                    equip_Manager_Player.ControlSet();
                }
            }
        }
        Tool_Manager.Instance.CloseTool();
    }
    public override void MiddleClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (item != null)
        {
            if (Canvas_Manager.Instance.IsOpenCarrierSlot())
            {
                Canvas_Manager.Instance.CloseCarrierSlot();
            }
            equip_Manager_Player.UnEquip(item as Equip_Item);
            Game_Manager.Instance.CreateItemBox(item, itemAmount);
            SlotBosalt();
        }
    }
    public override void RightClick()
    {
        if (canUseSlot)
        {
            return;
        }
        if (Canvas_Manager.Instance.IsOpenCarrierSlot())
        {
            Canvas_Manager.Instance.CloseCarrierSlot();
        }
        // if Equip has a skill
        (item as Equip_Item).UseSkill();
    }
}