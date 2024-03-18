using UnityEngine;

public class ForwardCar : BaseCar
{
    public float playerTargetDistance = 10f; // �÷��̾ ���� �����ϱ� �����ϴ� �Ÿ�

    // Movement �޼��带 �������̵��Ͽ� �÷��̾ ���� �����ϴ� ��� �߰�
    public override void Movement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

            // ������ �Ÿ����� ������ �÷��̾� ������ �̵�
            if (distanceToPlayer < playerTargetDistance)
            {
                Vector3 playerDirection = (player.transform.position - transform.position).normalized;
                transform.position += playerDirection * Time.deltaTime * maxMotorTorque;
            }
            else
            {
                // ������ �Ÿ����� �ָ� ������ ��������Ʈ �������� �̵�
                base.Movement();
            }
        }
        else
        {
            // �÷��̾ ã�� ���� ��쿡�� ��������Ʈ �������� �̵�
            base.Movement();
        }
    }
}
