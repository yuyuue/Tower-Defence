using UnityEngine;

public class Castle : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            DestroyCastle();
        }
    }

    void DestroyCastle()
    {
        // ゲームオーバー処理など
        Debug.Log("Castle Destroyed");
    }
}
