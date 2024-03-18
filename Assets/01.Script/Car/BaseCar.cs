using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class BaseCar : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float BreakForce;

    public Transform center;

    public Transform WayPoints;
    public Transform TargetPoint;
    [HideInInspector] public int WayIndex = 0;

    [HideInInspector] public Rigidbody rb;

    public float motor = 1000;
    [HideInInspector] public float steering = 0;
    [HideInInspector] public float Break = 0;



    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = center.localPosition;

    }
    // finds the corresponding visual wheel
    // correctly applies the transform
    public void LocalPosition(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {

        Movement();
    }

    public virtual void Movement()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            axleInfo.leftWheel.brakeTorque = Break;
            axleInfo.rightWheel.brakeTorque = Break;

            LocalPosition(axleInfo.leftWheel);
            LocalPosition(axleInfo.rightWheel);
        }
    }
}
