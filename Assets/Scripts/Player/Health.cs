using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("PLAYER DIED");
            // Här kan du lägga respawn/scene load senare
        }
    }
}
