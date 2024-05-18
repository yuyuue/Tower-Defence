using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float range = 5.0f;
    public float fireRate = 1.0f;
    public GameObject projectilePrefab;
    protected float fireCooldown = 0f;
    protected Transform target;

    public int level = 1; // �^���[�̃��x��
    public float damage = 1.0f; // ��{�_���[�W

    protected virtual void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (target == null || !IsTargetInRange(target))
        {
            FindTarget();
        }
        else
        {
            if (fireCooldown <= 0f)
            {
                FireProjectile();
                fireCooldown = 1f / fireRate;
            }
        }
    }

    protected void FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = hit.transform;
                }
            }
        }

        target = nearestEnemy;
    }

    protected bool IsTargetInRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) <= range;
    }

    protected abstract void FireProjectile();

    public void LevelUp()
    {
        level++;
        range += 1.0f; // ���x���A�b�v���ƂɎ˒������𑝉�
        fireRate += 0.2f; // ���x���A�b�v���Ƃɔ��˃��[�g�𑝉�
        damage += 0.5f; // ���x���A�b�v���ƂɃ_���[�W�𑝉�
    }

    void OnDrawGizmosSelected()
    {
        // �˒��͈͂�`��
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
