using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    public static Tower selectedTower;

    void OnMouseDown()
    {
        SelectTower();
    }

    void SelectTower()
    {
        if (selectedTower != null)
        {
            // �ȑO�̑I��������
            selectedTower.GetComponent<Renderer>().material.color = Color.white; // ��: ���̐F�ɖ߂�
        }
        selectedTower = GetComponent<Tower>();
        selectedTower.GetComponent<Renderer>().material.color = Color.yellow; // ��: �I�����ꂽ�^���[�̐F��ύX
    }
}
