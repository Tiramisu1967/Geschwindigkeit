using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private float RacingTime;
    public TextMeshProUGUI RacingTimeText;
    public TextMeshProUGUI LabText;

    private void Update()
    {
        RacingTime = GameInstance.instance.RacingTime;
        RacingTimeManager();
        LapManager();
    }

    public void RacingTimeManager()
    {
        RacingTimeText.text = $"Racing Time :{RacingTime:0.##}";
    }

    public void LapManager()
    {
        LabText.text = $"{GameInstance.instance.LabCount}/<color=#FFFFFF3C>{GameInstance.instance.MaxLab[GameInstance.instance.Stage-1]}</color> LAB";
    }
}
