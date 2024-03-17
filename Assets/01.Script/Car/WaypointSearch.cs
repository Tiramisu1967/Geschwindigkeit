using UnityEngine;

public class WaypointSearch : MonoBehaviour
{
    public GameObject[] Waypoints;
    public Transform Wayposition;

    void Start()
    {
        // 초기 Wayposition 설정
        if (Waypoints != null && Waypoints.Length > 0)
            Wayposition = Waypoints[0].transform;
    }

    void Update()
    {
        if (Waypoints == null || Waypoints.Length == 0)
            return;

        foreach (GameObject Way in Waypoints)
        {
            // Way가 null이 아닌지 확인
            if (Way == null)
                continue;

            // Wayposition이 설정되지 않았거나, 현재 Waypoint가 더 가까우면 Wayposition 업데이트
            if (Wayposition == null || Vector3.Distance(this.transform.position, Way.transform.position) < Vector3.Distance(this.transform.position, Wayposition.position))
            {
                Wayposition = Way.transform;
                for (int i = 0; i < Waypoints.Length; i++)
                {
                    if (Waypoints[i].transform == Wayposition)
                    {
                        Debug.Log("이거는 되는데");
                        GameInstance.instance.CurrentWayPointCount = i;
                        break;
                    }
                }
            }
            }
        
    }
}