using UnityEngine;

public class AISpawnManager : MonoBehaviour
{
    public GameObject ForwardCarPrefab;
    public GameObject ReverceCarPrefab;
    public GameObject[] WayPoints;
    public int SpawnWaypoint;
    public float SpawnCoolTime;
    private float CurrentSpawnTime;

    void Update()
    {
        if (CurrentSpawnTime <= 0)
        {
            CurrentSpawnTime = SpawnCoolTime;
            Spawn();
        }
        else
        {
            CurrentSpawnTime -= Time.deltaTime;
        }
    }

    void Spawn()
    {
        int Current = Random.Range(0, 2);
        switch (Current)
        {
            case 0:
            Debug.Log("?");
                ReverseWaypoint();
                break;
            case 1:
                ForwardWaypoint();
                break;
        }
    }

    void ReverseWaypoint()
    {
        if(GameInstance.instance == null)
        {
            Debug.Log("?????");

        }
        SpawnWaypoint = GameInstance.instance.CurrentWayPointCount + 2;
        if(SpawnWaypoint >= WayPoints.Length)
        {
            SpawnWaypoint -= WayPoints.Length;
        }
        Reverse();
    }

    void ForwardWaypoint()
    {
        if (GameInstance.instance == null)
        {
            Debug.Log("?????");

        }
        SpawnWaypoint = GameInstance.instance.CurrentWayPointCount - 2;
        if (SpawnWaypoint < 0)
        {
            SpawnWaypoint = WayPoints.Length - 2;
        }
        Forward();
    }
    void Reverse()
    {
        if (WayPoints[SpawnWaypoint] != null)
        {
            GameObject AI = Instantiate(ReverceCarPrefab, WayPoints[SpawnWaypoint].transform.position, Quaternion.identity);
            AI.gameObject.GetComponent<BaseCar>().WayIndex = SpawnWaypoint;
            Destroy(AI, 5);
        }
    }

    void Forward()
    {
        if (WayPoints[SpawnWaypoint] != null)
        {
            GameObject AI = Instantiate(ForwardCarPrefab, WayPoints[SpawnWaypoint].transform.position, Quaternion.identity);
            AI.gameObject.GetComponent<BaseCar>().WayIndex = SpawnWaypoint;
            Destroy(AI, 5);
        }
    }
}
