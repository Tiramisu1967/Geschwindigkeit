using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class CarMoveSystem : BaseCar
{
   public override void Movement()
    {
        motor = maxMotorTorque * UnityEngine.Input.GetAxis("Vertical");
        
        steering = maxSteeringAngle * UnityEngine.Input.GetAxis("Horizontal");
        Break = UnityEngine.Input.GetKey(KeyCode.Space) ? BreakForce : 0;
        base.Movement();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            Debug.Log("¿À...µÈ´Ù");
            motor = 100;
        }
    }

    public override void LocalPosition(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        if (TargetPoint == null) TargetPoint = WayPoints.GetChild(WayIndex);
        if (Vector3.Distance(TargetPoint.position, transform.position) <= 25 && WayPoints.childCount > WayIndex + 1)
        {
            Debug.Log(WayIndex);
            WayIndex++;
            TargetPoint = WayPoints.GetChild(WayIndex);

            if (WayPoints.childCount == WayIndex + 1)
            {
                GameInstance.instance._IsTurn = true;
                WayIndex = 0;
                TargetPoint = WayPoints.GetChild(WayIndex);
            }
        }
        GameInstance.instance.Speed = rb.velocity.magnitude * 3.6f;
        base.LocalPosition(collider);
    }

}