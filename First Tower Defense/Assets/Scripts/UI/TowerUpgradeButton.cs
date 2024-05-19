using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(UpgradeTower);
    }

    void UpgradeTower()
    {
        if (TowerSelection.selectedTower != null)
        {
            TowerSelection.selectedTower.LevelUp();
        }
    }
}
