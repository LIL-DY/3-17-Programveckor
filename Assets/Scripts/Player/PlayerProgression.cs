using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public int xp = 0;
    public int level = 1;
    public int xpNeeded = 100;

    public int upgradePoints = 0;

    public void AddXP(int amount)
    {
        xp += amount;

        while (xp >= xpNeeded)
        {
            xp -= xpNeeded;
            level++;
            xpNeeded += 100;

            upgradePoints += 1; // 1 poäng per level
            Debug.Log("Player LEVEL UP! Level: " + level + " | Upgrade Points: " + upgradePoints);
        }
    }

    public bool SpendUpgradePoint()
    {
        if (upgradePoints <= 0) return false;
        upgradePoints--;
        return true;
    }
}
