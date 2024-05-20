using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    private float RacingTime;
    public TextMeshProUGUI RacingTimeText;
    public TextMeshProUGUI LabText;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI ResultText;
    public RectTransform SpeedMeterneedle;


    private void Update()
    {
        RacingTime = GameInstance.instance.RacingTime;
        RacingTimeManager();
        LapManager();
        SpeedMeter();
        CoinUpdate();
    }

    public void CoinUpdate()
    {
        CoinText.text = $"Coin : {GameInstance.instance.Coin}$";
    }

    public IEnumerator Lose()
    {
        ResultText.text = $"your lose";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
    }

    public void RacingTimeManager()
    {
        RacingTimeText.text = $"Racing Time :{RacingTime:0.##}";
    }

    public void LapManager()
    {
        LabText.text = $"{GameInstance.instance.LabCount}/<color=#FFFFFF3C>{GameInstance.instance.MaxLab[GameInstance.instance.Stage-1]}</color> LAB";
    }


    private void Start()
    {
        
    }
    private void SpeedMeter()
    {
        SpeedMeterneedle.rotation = Quaternion.Euler(new Vector3(0, 0, 360 - (GameInstance.instance.Speed * 1.4f)));
    }
}
