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
        if (instance == null)  // 단 하나만 존재하게끔
        {
            instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
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
