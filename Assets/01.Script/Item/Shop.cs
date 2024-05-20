using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : BaseItme
{
    public override void Pick()
    {
        ShopManager shopManager = FindObjectOfType<ShopManager>();
        shopManager.Shop();
        base.Pick();
    }
}