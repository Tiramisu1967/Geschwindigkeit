using UnityEngine;

public class AISpawnManager : MonoBehaviour
{
    public GameObject ForwardCarPrefab;
    public GameObject ReverceCarPrefab;
    public GameObject Warning;
    public GameObject WarningPoint;
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

    void SpawnPoints()
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
        SpawnWaypoint = GameInstance.instance.CurrentWayPointCount + 1;
        if(SpawnWaypoint >= WayPoints.Length)
        {
            SpawnWaypoint -= WayPoints.Length;
        }
        Spawn();
    }

    void ForwardWaypoint()
    {
        if (GameInstance.instance == null)
        {
            Debug.Log("?????");

        }
        SpawnWaypoint = GameInstance.instance.CurrentWayPointCount - 1;
        if (SpawnWaypoint < 0)
        {
            SpawnWaypoint = WayPoints.Length - 1;
        }
        Spawn();
    }
    void Spawn()
    {
        if (WayPoints[SpawnWaypoint] != null)
        {
            GameObject WarningImage = Instantiate(Warning, WarningPoint.transform.position, Quaternion.identity);
            GameObject AI = Instantiate(ReverceCarPrefab, WayPoints[SpawnWaypoint].transform.position, Quaternion.identity);
            AI.gameObject.GetComponent<BaseCar>().WayIndex = SpawnWaypoint;
            WarningImage.GetComponent<WarningSystem>().WarningTarget = AI;
            WarningImage.GetComponent<WarningSystem>().WarningFloow = WarningPoint;
            Destroy(AI, 5);
        }
    }

}
