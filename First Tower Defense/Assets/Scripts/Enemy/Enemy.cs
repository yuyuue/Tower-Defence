using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypoints; // �ړ����郋�[�g�̃|�C���g
    private int currentWaypointIndex = 0; // ���݂̃E�F�C�|�C���g�C���f�b�N�X
    public virtual float speed { get; set; }// �ړ����x
    public virtual float hitpoint { get; set; }// �̗�

    public float damage = 1f; // �G�l�~�[����ɗ^����_���[�W
    public Castle castle; // ��̎Q��

    private void Start()
    {
        waypoints = WaypointsManager.Instance.waypoints;
        castle = FindObjectOfType<Castle>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // �E�F�C�|�C���g�̏I���ɒB�����Ƃ��̏���
            //waypointIndex = 0; // ���[�g���ĊJ���邩�A�G�l�~�[���A�N�e�B�u�ɂ��铙
            speed = 0.0f;
        }
    }

    public void TakeDamage(float amount)
    {
        hitpoint -= amount;
        if (hitpoint <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // �G�����S�����ۂ̏���
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            DealDamage();
        }
    }

    void DealDamage()
    {
        if (castle != null)
        {
            castle.TakeDamage(damage);
            Destroy(gameObject); // �_���[�W��^������ɃG�l�~�[��j��
        }
    }
}
