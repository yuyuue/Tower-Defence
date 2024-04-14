using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // 移動するルートのポイント
    private int waypointIndex = 0; // 現在のウェイポイントインデックス
    public float speed = 5.0f; // 移動速度

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                Debug.Log("waypointIndexをインクリメント");
                waypointIndex++;
            }
        }
        else
        {
            // ウェイポイントの終わりに達したときの処理
            waypointIndex = 0; // ルートを再開するか、エネミーを非アクティブにする等
        }
    }
}
