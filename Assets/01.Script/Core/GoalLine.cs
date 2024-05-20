using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLine : MonoBehaviour
{
    public Canvas Shop;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameInstance.instance._IsTurn)
            {
                if(GameInstance.instance.LabCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage] -1)
                {
                    if(GameInstance.instance.Stage >= 3)
                    {
                        SceneManager.LoadScene("Main");
                    } else
                    {
                        GameInstance.instance.Stage += 1;
                        Debug.Log("a");
                        ShopManager shopManager = Shop.GetComponent<ShopManager>();
                        shopManager.Shop();
                    }
                } else
                {
                    GameInstance.instance.LabCount++;
                    GameInstance.instance._IsTurn = false;
                }
            }
        }
    }
}
