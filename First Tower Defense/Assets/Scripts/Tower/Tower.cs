using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Tower : MonoBehaviour
{
    public float range;       // 攻撃範囲
    public float damage;      // 一撃のダメージ
    public float fireRate;    // 発射間隔

    protected virtual void Start()
    {
        InitializeTower();
    }

    protected abstract void InitializeTower();

    public abstract void Attack();

    protected void Update()
    {
        // ここにタワーの攻撃ロジックを実装
        // 例: 敵を検知して攻撃する
        if (CanAttack())
        {
            Attack();
        }
    }

    protected abstract bool CanAttack();
}