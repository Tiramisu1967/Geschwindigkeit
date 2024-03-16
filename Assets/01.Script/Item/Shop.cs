using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineShop : BaseItme
{
    public GameObject ShopCanvas;
    public override void Pick()
    {
        Time.timeScale = 0f;
        Instantiate(ShopCanvas);
        base.Pick();
    }
}