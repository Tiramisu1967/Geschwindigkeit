using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{
    public Sprite PartImage;
    public int Coin;

    public virtual void GetPart()
    {
        Debug.Log("�ƹ�ư �ǰ� ���� ����");
    }
}
