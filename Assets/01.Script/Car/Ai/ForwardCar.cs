using UnityEngine;

public class ForwardCar : BaseCar
{
    public float playerTargetDistance = 10f; // 플레이어를 향해 돌진하기 시작하는 거리

    // Movement 메서드를 오버라이드하여 플레이어를 향해 돌진하는 기능 추가
    public override void Movement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

            // 설정한 거리보다 가까우면 플레이어 쪽으로 이동
            if (distanceToPlayer < playerTargetDistance)
            {
                Vector3 playerDirection = (player.transform.position - transform.position).normalized;
                transform.position += playerDirection * Time.deltaTime * maxMotorTorque;
            }
            else
            {
                // 설정한 거리보다 멀면 기존의 웨이포인트 방향으로 이동
                base.Movement();
            }
        }
        else
        {
            // 플레이어를 찾지 못한 경우에는 웨이포인트 방향으로 이동
            base.Movement();
        }
    }
}
