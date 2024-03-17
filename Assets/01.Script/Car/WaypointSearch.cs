using UnityEngine;

public class WaypointSearch : MonoBehaviour
{
    public GameObject[] Waypoints;
    public Transform Wayposition;

    void Start()
    {
        // �ʱ� Wayposition ����
        if (Waypoints != null && Waypoints.Length > 0)
            Wayposition = Waypoints[0].transform;
    }

    void Update()
    {
        if (Waypoints == null || Waypoints.Length == 0)
            return;

        foreach (GameObject Way in Waypoints)
        {
            // Way�� null�� �ƴ��� Ȯ��
            if (Way == null)
                continue;

            // Wayposition�� �������� �ʾҰų�, ���� Waypoint�� �� ������ Wayposition ������Ʈ
            if (Wayposition == null || Vector3.Distance(this.transform.position, Way.transform.position) < Vector3.Distance(this.transform.position, Wayposition.position))
            {
                Wayposition = Way.transform;
                for (int i = 0; i < Waypoints.Length; i++)
                {
                    if (Waypoints[i].transform == Wayposition)
                    {
                        Debug.Log("�̰Ŵ� �Ǵµ�");
                        GameInstance.instance.CurrentWayPointCount = i;
                        break;
                    }
                }
            }
            }
        
    }
}