using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private EnemySpawner spawner;
    private SpriteRenderer sr;

    public Color hitColor = Color.red;   // колір при ударі
    public float flashDuration = 0.1f;   // тривалість ефекту

    private void Start()
    {
        currentHealth = maxHealth;
        spawner = FindFirstObjectByType<EnemySpawner>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        StartCoroutine(HitFlash()); // запускаємо ефект удару

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator HitFlash()
    {
        Color originalColor = sr.color;
        sr.color = hitColor;

        yield return new WaitForSeconds(flashDuration);

        sr.color = originalColor;
    }

    void Die()
    {
        if (spawner != null)
            spawner.OnEnemyKilled();

        Destroy(gameObject);
    }
}
