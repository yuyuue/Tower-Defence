using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // �ړ����郋�[�g�̃|�C���g
    private int waypointIndex = 0; // ���݂̃E�F�C�|�C���g�C���f�b�N�X
    public float speed = 5.0f; // �ړ����x

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                Debug.Log("waypointIndex���C���N�������g");
                waypointIndex++;
            }
        }
        else
        {
            // �E�F�C�|�C���g�̏I���ɒB�����Ƃ��̏���
            waypointIndex = 0; // ���[�g���ĊJ���邩�A�G�l�~�[���A�N�e�B�u�ɂ��铙
        }
    }
}
