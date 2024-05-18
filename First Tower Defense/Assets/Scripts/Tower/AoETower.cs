using UnityEngine;

public class AoETower : Tower
{
    public float explosionRadius = 3.0f; // 範囲攻撃の半径

    protected override void FireProjectile()
    {
        if (target != null)
        {
            Debug.Log("FireProjectile called");

            // 弾を生成するが、弾の代わりに範囲攻撃を行う
            Explode();
        }
    }

    void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(projectilePrefab.GetComponent<Projectile>().damage); // プロジェクタイルのダメージを使用
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 攻撃範囲の半径を示すためにギズモを描画
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // 基底クラスの範囲も描画
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
