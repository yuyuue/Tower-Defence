using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public Transform target; // 回転の中心となるターゲット
    public float distance = 10.0f; // ターゲットからの距離
    public float xSpeed = 120.0f; // 水平方向の回転速度
    public float ySpeed = 120.0f; // 垂直方向の回転速度
    public float zoomSpeed = 10.0f; // 垂直方向の回転速度
    public float yMinLimit = -20f; // 垂直方向の回転制限（最小角度）
    public float yMaxLimit = 80f; // 垂直方向の回転制限（最大角度）
    public float distanceMin = 2f; // ズームインの最小距離
    public float distanceMax = 15f; // ズームアウトの最大距離

    private float x = 0.0f; // 初期水平回転角度
    private float y = 0.0f; // 初期垂直回転角度

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // カーソルを表示する
        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(1)) // 右クリックでカメラを回転
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }

            // ズームイン・ズームアウト
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, distanceMin, distanceMax);

            // カメラの位置を更新
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // 角度を制限する関数
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
