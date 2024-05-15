using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETower : Tower
{
    public LayerMask enemyLayer;  // �G�����o���邽�߂̃��C���[�}�X�N

    protected override void InitializeTower()
    {
        // �͈͍U���^���[���L�̏���������
        Debug.Log("AoE Tower initialized.");
    }

    public override void Attack()
    {
        // �͈͓��̂��ׂĂ̓G�ɍU�����s�����W�b�N
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, range, enemyLayer);
        foreach (Collider enemy in enemiesInRange)
        {
            // �����Ŋe�G�Ƀ_���[�W��^���鏈�����Ăяo��
            Debug.Log("Attacking an enemy with AoE damage.");
        }
    }

    protected override bool CanAttack()
    {
        // �U���\���ǂ����𔻒肷�郍�W�b�N
        // �͈͓��ɓG�����邩�ǂ������`�F�b�N
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, range, enemyLayer);
        return enemiesInRange.Length > 0;
    }
}
