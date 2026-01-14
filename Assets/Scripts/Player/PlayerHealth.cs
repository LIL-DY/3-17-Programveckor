using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public TMP_Text healthText;
    public Slider healthSlider;
    public GameObject healthBarObject;

    public float regenDelay = 60f;
    public float regenTickTime = 1f;

    public UnityEvent OnDamage;

    private Coroutine regenCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateUI();
        OnDamage?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }

        if (regenCoroutine != null)
            StopCoroutine(regenCoroutine);

        regenCoroutine = StartCoroutine(HealthRegen());
    }

    private IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(regenDelay);

        while (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateUI();
            yield return new WaitForSeconds(regenTickTime);
        }
    }

    private void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "HP: " + currentHealth + "/" + maxHealth;

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (healthBarObject != null)
            healthBarObject.SetActive(currentHealth < maxHealth);
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        gameObject.SetActive(false);
    }
}