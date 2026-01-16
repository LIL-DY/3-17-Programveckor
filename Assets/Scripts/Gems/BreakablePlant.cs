using UnityEngine;

public class BreakablePlant : MonoBehaviour
{
    public int hp = 3;

    [Header("Drop")]
    public GameObject gemPrefab;
    [Range(0f, 1f)] public float dropChance = 0.4f; // 40% chans
    public int minGems = 1;
    public int maxGems = 2;

    bool dead;

    public void TakeDamage(int amount)
    {
        if (dead) return;

        hp -= amount;

        if (hp <= 0)
            Die();
    }

    void Die()
    {
        dead = true;

        // Drop gems
        if (gemPrefab != null && Random.value <= dropChance)
        {
            int count = Random.Range(minGems, maxGems + 1);

            for (int i = 0; i < count; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 0.25f;
                Instantiate(gemPrefab, (Vector2)transform.position + offset, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}
