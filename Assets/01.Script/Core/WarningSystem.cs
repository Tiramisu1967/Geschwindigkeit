using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSystem : MonoBehaviour
{
    public GameObject WarningTarget;
    public GameObject WarningFloow;
    void Update()
    {
        if (WarningTarget == null)
        {
            Destroy(this.gameObject);
        }
        transform.position = WarningFloow.transform.position;
        transform.LookAt(WarningTarget.transform);
    }
}
