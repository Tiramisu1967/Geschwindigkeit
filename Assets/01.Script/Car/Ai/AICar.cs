using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : BaseCar
{
    private float Tmp;
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
                WayIndex = 0;
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
