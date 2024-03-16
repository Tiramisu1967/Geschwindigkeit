using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public int Page = 0;
    public GameObject[] ShopPage;

    public void NextPage()
    {
        switch (Page)
        {
            case 0:
                ShopPage[Page].SetActive(false);
                Page = 1;
                ShopPage[Page].SetActive(true); 
                break;
            case 1:
                ShopPage[Page].SetActive(false);
                Page = 0;
                ShopPage[Page].SetActive(true);
                break;
        }
    }

    public void Partsale(BasePart part)
    {
        if (part.Coin <= GameInstance.instance.Coin)
            GameInstance.instance.Coin -= part.Coin;
            part.GetPart();
    }
}
