using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Equip_Slot : Slot
{
    public Canvas_Manager canvas_Manager;
    public Equip_Manager_Player equip_Manager_Player;
    public Body_Part bodyPart;
    /// equip slot       : Sol tık - çıkart + orta tık - yere at + sağ tık - kullan
    public override void LeftClick()
    {
        if (canvas_Manager.IsOpenCarrierSlot())
        {
            if (canvas_Manager.CarrierSlotItem() is Equip_Item)
            {
                Equip_Item equip_Item = canvas_Manager.CarrierSlotItem() as Equip_Item;
                if (bodyPart == equip_Item.bodyPart)
                {
                    if (equip_Item.ciftKol)
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
                        }
                        else if (yerlerDolumu == 1)
                        {
                            Equip_Item equip_Item1 = item as Equip_Item;
                            Equip_Item equip_Item2 = equip_Manager_Player.equipSlot[6].item as Equip_Item;
                            if (equip_Item1 != null)
                            {
                                equip_Manager_Player.UnEquip(equip_Item1);
                                SlotBosalt();
                            }
                            if (equip_Item2 != null)
                            {
                                equip_Manager_Player.UnEquip(equip_Item2);
                                equip_Manager_Player.equipSlot[6].SlotBosalt();
                            }
                            SlotDoldur(equip_Item, 1);
                            equip_Manager_Player.Equip(equip_Item);
                        }
                        else if (yerlerDolumu == 2)
                        {
                            Equip_Item equip_Item1 = item as Equip_Item;
                            Equip_Item equip_Item2 = equip_Manager_Player.equipSlot[6].item as Equip_Item;
                            equip_Manager_Player.UnEquip(equip_Item1);
                            SlotBosalt();
                            equip_Manager_Player.UnEquip(equip_Item2);
                            equip_Manager_Player.equipSlot[6].SlotBosalt();
                            SlotDoldur(equip_Item, 1);
                            equip_Manager_Player.Equip(equip_Item);
                        }
                    }
                    else
                    {
                        if (SlotDolumu())
                        {
                            equip_Manager_Player.UnEquip(item as Equip_Item);
                        }
                        equip_Manager_Player.Equip(equip_Item);
                        SlotDoldur(equip_Item, 1);
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
                }
            }
        }
    }
    public override void MiddleClick()
    {
        if (item != null)
        {
            equip_Manager_Player.UnEquip(item as Equip_Item);
            Game_Manager.Instance.CreateItemBox(item, itemAmount);
            SlotBosalt();
        }
    }
    public override void RightClick()
    {
        // if Equip has a skill
        (item as Equip_Item).UseSkill();
    }
}