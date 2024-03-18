using System;
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

}