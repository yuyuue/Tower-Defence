using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : Tower
{
    protected override void InitializeTower()
    {
        // ����̏���������
    }

    public override void Attack()
    {
        // �P��̓G�ɍU�����s�����W�b�N
        Debug.Log("Attacking an enemy with single shot.");
    }

    protected override bool CanAttack()
    {
        // �U���\���ǂ����𔻒肷�郍�W�b�N
        return true; // ���̎���
    }
}
