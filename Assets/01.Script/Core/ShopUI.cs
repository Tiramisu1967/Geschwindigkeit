using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public void Partsale(BasePart part)
    {
        if (part.Coin <= GameInstance.instance.Coin)
            GameInstance.instance.Coin -= part.Coin;
            part.GetPart();
    }
}
