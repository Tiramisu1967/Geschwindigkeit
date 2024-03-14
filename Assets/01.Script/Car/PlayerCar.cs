using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    private CarMoveSystem _carMoveSystem;
    void Start()
    {
        _carMoveSystem = GetComponent<CarMoveSystem>();
    }

    void FixedUpdate()
    {
        MoveInput();
    }

    void MoveInput()
    {
        float motorTorque = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        bool isbreak = Input.GetKey(KeyCode.Space);

        _carMoveSystem.MoveWheel(motorTorque, steer, isbreak);
    }

}