using UnityEngine;

public class Tower : MonoBehaviour
{
    public XPSystem xpSystem;

    public int damage = 10;
    public float range = 3f;

    int lastLevel;

    void Start()
    {
        lastLevel = xpSystem.level;
        ApplyStats();
    }

    void Update()
    {
        if (xpSystem.level != lastLevel)
        {
            lastLevel = xpSystem.level;
            ApplyStats();
        }
    }

    void ApplyStats()
    {
        damage = 10 + (xpSystem.level - 1) * 5;
        range = 3f + (xpSystem.level - 1) * 0.5f;

        Debug.Log("Tower level " + xpSystem.level +
                  " | Damage: " + damage +
                  " | Range: " + range);
    }
}
