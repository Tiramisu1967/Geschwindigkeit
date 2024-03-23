using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLine : MonoBehaviour
{
    public Canvas Shop;
    private int AILabCount;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameInstance.instance._IsTurn)
        {
            Debug.Log("실행 됨");
            GameInstance.instance.LabCount += 1;
            GameInstance.instance._IsTurn = false;
            if (GameInstance.instance.LabCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage - 1])
            {
                if(GameInstance.instance.Stage >= 3)
                {
                    SceneManager.LoadScene("Main");
                }
                else
                {
                    GameInstance.instance.isClear = true;
                    GameInstance.instance.Stage++;
                    Shop.gameObject.SetActive(true);
                    GameInstance.instance.LabCount = 0;
                }
            } 
        }
        else if (other.gameObject.CompareTag("AIPlayer"))
        {
            if (AILabCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage - 1])
            {
                GameInstance.instance.LabCount = 0;
                SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
            } else
            {
                AILabCount += 1;
            }
        }
        else if(GameInstance.instance._IsTurn)
        {
            Debug.Log("태그 문제");
        }
    }
}
