using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject[] ItemPrefab;
    public Transform[] SpawnPoints;
    public void Start()
    {
        ItemSpawn();
    }

    public void ItemSpawn()
    {
        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            Vector3 Current1 = SpawnPoints[i].position + new Vector3(-3, 0, 0);
            Vector3 Current2 = SpawnPoints[i].position + new Vector3(0, 0, -3);
            Instantiate(ItemPrefab[Random.Range(0, ItemPrefab.Length)], SpawnPoints[i]);
        }
    }
}
