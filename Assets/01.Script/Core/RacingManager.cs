using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingManager : MonoBehaviour
{
    public Canvas HelpCnavas;
    public Canvas RackingCnavas;
    public Canvas MainCanvas;
    public void GameStart()
    {
        if(GameInstance.instance != null)
        {
            GameInstance.instance.Coin = 0;
            GameInstance.instance.CurrentWayPointCount = 0;
            GameInstance.instance.LabCount = 0;
            GameInstance.instance.RacingTime = 0;
            GameInstance.instance.Score = 0;
            GameInstance.instance.Stage = 1;
            GameInstance.instance._IsTurn = false;
        }
        SceneManager.LoadScene("Stage1");
    }
    
    public void MainMenu()
    {
        RackingCnavas.gameObject.SetActive(false);
        HelpCnavas.gameObject.SetActive(false);
    }

    public void HelpBox()
    {
        HelpCnavas.gameObject.SetActive(true);
    }
}
