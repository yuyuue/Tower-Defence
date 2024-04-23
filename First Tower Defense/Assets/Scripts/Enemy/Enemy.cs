using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypoints; // 移動するルートのポイント
    private int currentWaypointIndex = 0; // 現在のウェイポイントインデックス
    public virtual float speed { get; set; }// 移動速度
    public virtual float hitpoint { get; set; }// 体力

    private void Start()
    {
        waypoints = WaypointsManager.Instance.waypoints;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                Debug.Log("waypointIndexをインクリメント");
                currentWaypointIndex++;
            }
        }
        else
        {
            // ウェイポイントの終わりに達したときの処理
            //waypointIndex = 0; // ルートを再開するか、エネミーを非アクティブにする等
            speed = 0.0f;
        }
    }
}
