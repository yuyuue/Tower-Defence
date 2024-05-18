using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeButton : MonoBehaviour
{
    public Tower tower; // レベルアップさせたいタワー

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(UpgradeTower);
    }

    void UpgradeTower()
    {
        if (tower != null)
        {
            tower.LevelUp();
        }
    }
}
