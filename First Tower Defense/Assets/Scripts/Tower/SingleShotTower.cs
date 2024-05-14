using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : Tower
{
    protected override void InitializeTower()
    {
        // 特定の初期化処理
    }

    public override void Attack()
    {
        // 単一の敵に攻撃を行うロジック
        Debug.Log("Attacking an enemy with single shot.");
    }

    protected override bool CanAttack()
    {
        // 攻撃可能かどうかを判定するロジック
        return true; // 仮の実装
    }
}
