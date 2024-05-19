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
            // 以前の選択を解除
            selectedTower.GetComponent<Renderer>().material.color = Color.white; // 例: 元の色に戻す
        }
        selectedTower = GetComponent<Tower>();
        selectedTower.GetComponent<Renderer>().material.color = Color.yellow; // 例: 選択されたタワーの色を変更
    }
}
