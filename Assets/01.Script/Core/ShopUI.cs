using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    public Canvas Shop;
    public Canvas Main;
    public int[] WheelCoin;
    public int[] EngineCoin;

    private void Start()
    {
        Main.gameObject.SetActive(false);
    }

    public void Wheelsale()
    {
        if(GameInstance.instance.Coin >= WheelCoin[GameInstance.instance.Part[1]] && GameInstance.instance.Part[1] != 3)
        {
            GameInstance.instance.Coin -= WheelCoin[GameInstance.instance.Part[1]];
            GameInstance.instance.Part[1] += 1; 
        }
    }

    public void Exit()
    {
        Debug.Log("눌림");
        if (GameInstance.instance.isClear)
        {
            GameInstance.instance.isClear = false;
            Debug.Log("오 다음 스테이지");
            Time.timeScale = 1;
            SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
        } else
        {
            Debug.Log("진행");
            Time.timeScale = 1;
            Shop.gameObject.SetActive(false);
        }
    }

    public void Enginesale()
    {
        if (GameInstance.instance.Coin >= EngineCoin[GameInstance.instance.Part[0]] && GameInstance.instance.Part[0] != 2)
        {
            GameInstance.instance.Coin -= EngineCoin[GameInstance.instance.Part[0]];
            GameInstance.instance.Part[0] += 1;
        }
    }
}
