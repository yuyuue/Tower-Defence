using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public Transform target; // ��]�̒��S�ƂȂ�^�[�Q�b�g
    public float distance = 10.0f; // �^�[�Q�b�g����̋���
    public float xSpeed = 120.0f; // ���������̉�]���x
    public float ySpeed = 120.0f; // ���������̉�]���x
    public float zoomSpeed = 10.0f; // ���������̉�]���x
    public float yMinLimit = -20f; // ���������̉�]�����i�ŏ��p�x�j
    public float yMaxLimit = 80f; // ���������̉�]�����i�ő�p�x�j
    public float distanceMin = 2f; // �Y�[���C���̍ŏ�����
    public float distanceMax = 15f; // �Y�[���A�E�g�̍ő勗��

    private float x = 0.0f; // ����������]�p�x
    private float y = 0.0f; // ����������]�p�x

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // �J�[�\����\������
        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(1)) // �E�N���b�N�ŃJ��������]
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }

            // �Y�[���C���E�Y�[���A�E�g
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, distanceMin, distanceMax);

            // �J�����̈ʒu���X�V
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // �p�x�𐧌�����֐�
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
