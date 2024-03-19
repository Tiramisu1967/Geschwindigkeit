using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawn : MonoBehaviour
{
    public float Cooltime = 0;
    public float MaxCooltime = 1.5f;
    public Transform Spawn;
    public GameObject Prefab;
    // Update is called once per frame
    void Update()
    {

        if(0 >= Cooltime)
        {
            GameObject SpawnEnemy = Instantiate(Prefab, Spawn.position, Quaternion.identity);
            Cooltime = MaxCooltime;
            Destroy(SpawnEnemy, MaxCooltime);

        }else
        {
            Cooltime -= Time.deltaTime;
        }
    }
}
