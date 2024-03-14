using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{
    public Sprite PartImage;
    public int Coin;

    public virtual void GetPart()
    {
        Debug.Log("아무튼 되고 있음 ㅇㅇ");
    }
}
