using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETower : Tower
{
    public LayerMask enemyLayer;  // 敵を検出するためのレイヤーマスク

    protected override void InitializeTower()
    {
        // 範囲攻撃タワー特有の初期化処理
        Debug.Log("AoE Tower initialized.");
    }

    public override void Attack()
    {
        // 範囲内のすべての敵に攻撃を行うロジック
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, range, enemyLayer);
        foreach (Collider enemy in enemiesInRange)
        {
            // ここで各敵にダメージを与える処理を呼び出す
            Debug.Log("Attacking an enemy with AoE damage.");
        }
    }

    protected override bool CanAttack()
    {
        // 攻撃可能かどうかを判定するロジック
        // 範囲内に敵がいるかどうかをチェック
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, range, enemyLayer);
        return enemiesInRange.Length > 0;
    }
}
