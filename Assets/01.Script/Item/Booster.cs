using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : BaseItme
{
    public int Speed;
    public override void Pick()
    {
        Rigidbody CarRigid = Player.GetComponent<Rigidbody>();

        CarRigid.velocity = CarRigid.transform.forward * Speed;
        base.Pick();
    }
}