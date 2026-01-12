using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;

    private void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthText();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + currentHealth + "/ " + maxHealth;
    }
}
