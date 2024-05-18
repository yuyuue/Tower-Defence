using UnityEngine;

public class SingleShotTower : Tower
{
    protected override void FireProjectile()
    {
        if (target != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projScript = projectile.GetComponent<Projectile>();
            if (projScript != null)
            {
                projScript.SetTarget(target);
                projScript.damage = damage; // É_ÉÅÅ[ÉWÇîΩâf
            }
        }
    }
}
