using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public Canvas ShopCanvas;
    public Canvas Main;
    public int[] WheelCoin;
    public int[] EngineCoin;

    private void Start()
    {
        Main.gameObject.SetActive(false);
    }

    public void Shop()
    {
        ShopCanvas.gameObject.SetActive(true);
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
        if (GameInstance.instance._IsTurn)
        {
            GameInstance.instance._IsTurn = false;
            GameInstance.instance.LabCount = 0;
            SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Enginesale()
    {
        if (GameInstance.instance.Coin >= EngineCoin[GameInstance.instance.Part[0]] && GameInstance.instance.PartLaval <=2)
        {
            if (GameInstance.instance.PartLaval == 1) { GameInstance.instance.Coin -= EngineCoin[GameInstance.instance.Part[0]];
                GameInstance.instance.PartLaval += 1; 
            }
            else
            {
                GameInstance.instance.Coin -= GameInstance.instance.Part[1];
                GameInstance.instance.PartLaval += 1;
            }
        }
    }
}
