using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHP = 30;
    public int currentHP;

    [Header("XP reward on death")]
    public int xpReward = 25;

    PlayerProgression playerProgression;

    void Awake()
    {
        currentHP = maxHP;

        // Hitta PlayerProgression på GameManager (en gång)
        playerProgression = FindFirstObjectByType<PlayerProgression>();
        if (playerProgression == null)
            Debug.LogError("PlayerProgression hittades inte i scenen!");
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
            enemyDie();
    }

    void enemyDie()
    {
        if (playerProgression != null)
            playerProgression.AddXP(xpReward);

        Destroy(gameObject);
    }
}
