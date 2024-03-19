using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void NextMap()
    {
        if(GameInstance.instance.Stage < 3)
        {
            GameInstance.instance.Stage += 1;
        }
        SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
    }

}
