using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AICar : BaseCar
{
    private float AiCount;
    public override void Movement()
    {
        if (TargetPoint == null) TargetPoint = WayPoints.GetChild(WayIndex);
        if (Vector3.Distance(TargetPoint.position, transform.position) == 50) Break = BreakForce;
        if (Vector3.Distance(TargetPoint.position, transform.position) <= 10)
        {
            Debug.Log(WayIndex);
            WayIndex++;

            if (WayPoints.childCount == WayIndex -1)
            {
                if (AiCount == GameInstance.instance.MaxLab[GameInstance.instance.Stage]) 
                {
                    PlayerUI playerui = FindAnyObjectByType<PlayerUI>();
                    StartCoroutine(playerui.Lose());
                    GameInstance.instance.LabCount = 0;
                    SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
                }
                Debug.Log("실행 되는 중");
                WayIndex = 0;
                AiCount += 1; 
                TargetPoint = WayPoints.GetChild(0);
            } 
            TargetPoint = WayPoints.GetChild(WayIndex);
        }
        Vector3 waypointRelativeDistance = transform.InverseTransformPoint(TargetPoint.position);
        waypointRelativeDistance /= waypointRelativeDistance.magnitude;
        steering = (waypointRelativeDistance.x / waypointRelativeDistance.magnitude) * 25;
        base.Movement();
    }
}
