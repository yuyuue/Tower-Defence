using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Tower : MonoBehaviour
{
    public float range;       // �U���͈�
    public float damage;      // �ꌂ�̃_���[�W
    public float fireRate;    // ���ˊԊu

    protected virtual void Start()
    {
        InitializeTower();
    }

    protected abstract void InitializeTower();

    public abstract void Attack();

    protected void Update()
    {
        // �����Ƀ^���[�̍U�����W�b�N������
        // ��: �G�����m���čU������
        if (CanAttack())
        {
            Attack();
        }
    }

    protected abstract bool CanAttack();
}