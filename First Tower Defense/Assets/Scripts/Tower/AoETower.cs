using UnityEngine;

public class AoETower : Tower
{
    public float explosionRadius = 3.0f; // �͈͍U���̔��a

    protected override void FireProjectile()
    {
        if (target != null)
        {
            Debug.Log("FireProjectile called");

            // �e�𐶐����邪�A�e�̑���ɔ͈͍U�����s��
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
                    enemy.TakeDamage(projectilePrefab.GetComponent<Projectile>().damage); // �v���W�F�N�^�C���̃_���[�W���g�p
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // �U���͈͂̔��a���������߂ɃM�Y����`��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // ���N���X�͈̔͂��`��
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
