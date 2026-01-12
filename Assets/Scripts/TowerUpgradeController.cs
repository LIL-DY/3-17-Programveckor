using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    public PlayerProgression playerProgression;
    public Tower tower;

    public void TryUpgradeTower()
    {
        if (playerProgression.SpendUpgradePoint())
        {
            tower.UpgradeTower();
        }
        else
        {
            Debug.Log("No upgrade points!");
        }
    }
}
