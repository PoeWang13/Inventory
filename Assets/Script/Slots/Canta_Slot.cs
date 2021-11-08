using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Canta_Slot : Slot
{
    /// çanta slot       : orta tık - yere at
    public override void MiddleClick()
    {
        if (myInventory.CantaSil(this))
        {
            SlotBosalt();
        }
    }
}