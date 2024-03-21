using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLine : MonoBehaviour
{

    private int AILabCount;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameInstance.instance._IsTurn)
        {
            Debug.Log("���� ��");
            GameInstance.instance.LabCount += 1;
            GameInstance.instance._IsTurn = false;
            if (GameInstance.instance.LabCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage - 1])
            {
                GameInstance.instance.LabCount = 0;
                GameManager gameManager = FindAnyObjectByType<GameManager>();
                gameManager.NextMap();
            } 
        }
        else if (other.gameObject.CompareTag("AIPlayer"))
        {
            if (AILabCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage - 1])
            {
                GameInstance.instance.LabCount = 0;
                SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
            }
        }
        else if(GameInstance.instance._IsTurn)
        {
            Debug.Log("�±� ����");
        }
    }
}
