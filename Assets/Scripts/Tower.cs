using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerLevel = 1;

    public int damage = 10;
    public float range = 3f;

    public void UpgradeTower()
    {
        towerLevel++;
        ApplyStats();

        Debug.Log("Tower upgraded! Tower Level: " + towerLevel);
    }

    void Start()
    {
        ApplyStats();
    }

    void ApplyStats()
    {
        damage = 10 + (towerLevel - 1) * 5;
        range = 3f + (towerLevel - 1) * 0.5f;
    }
}
