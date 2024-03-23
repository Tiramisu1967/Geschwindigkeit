using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance;
    public int Coin;
    public int Stage;
    public float RacingTime;
    public int CurrentWayPointCount = 0;
    public int LabCount;
    public float Speed;
    public int[] MaxLab;
    public bool _IsTurn;
    public bool isClear;
    public int[] Part;

    private void Awake()
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        RacingTime += Time.deltaTime;
    }

}
