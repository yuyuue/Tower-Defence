using UnityEngine;

public class HeavyEnemy : Enemy
{
    [SerializeField] private float Speed = 5.0f; // ˆÚ“®‘¬“x
    [SerializeField] private float Hitpoint = 100f; //‘Ì—Í

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
