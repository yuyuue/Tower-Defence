using UnityEngine;

public class HeavyEnemy : Enemy
{
    [SerializeField] private float Speed = 5.0f; // 移動速度
    [SerializeField] private float Hitpoint = 100f; //体力

    public override float speed
    {
        get => Speed;
        set => Speed = value;
    }
    public override float hitpoint
    {
        get => Hitpoint;
        set => Hitpoint = value;
    }
}
