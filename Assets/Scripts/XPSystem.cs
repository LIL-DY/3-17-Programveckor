using UnityEngine;

public class XPSystem : MonoBehaviour
{
    public int xp = 0;
    public int level = 1;
    public int xpNeeded = 100;

    public void AddXP(int amount)
    {
        xp += amount;

        if (xp >= xpNeeded)
        {
            xp -= xpNeeded;
            level++;
            xpNeeded += 100;

            Debug.Log("LEVEL UP! Level: " + level);
        }
    }
}
