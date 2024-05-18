using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float range = 5.0f;
    public float fireRate = 1.0f;
    public GameObject projectilePrefab;
    protected float fireCooldown = 0f;
    protected Transform target;

    public int level = 1; // タワーのレベル
    public float damage = 1.0f; // 基本ダメージ

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
        range += 1.0f; // レベルアップごとに射程距離を増加
        fireRate += 0.2f; // レベルアップごとに発射レートを増加
        damage += 0.5f; // レベルアップごとにダメージを増加
    }

    void OnDrawGizmosSelected()
    {
        // 射程範囲を描画
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
