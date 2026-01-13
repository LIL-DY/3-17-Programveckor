using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerHealthbar : MonoBehaviour
{
    public int PHealth = 10;
    public int CurentHealth;
   
    public Slider PHealthbar;
    public GameObject healthbarOBJ;

    public float regenDelay = 60f;
    public float regenTickBack = 1f;

    private Coroutine regenCoroutine;

    public UnityEvent OnDamage;

    private void Start()
    {
        CurentHealth = PHealth;
        UpdateHeal();
    }

    private void Update()
    {        
        PHealthbar.value -= PHealth; 
    }

    public void DamageTake(int damage)
    {
        CurentHealth -= damage;
        Debug.Log("P HP" + PHealth);
        OnDamage?.Invoke();
        if (CurentHealth <= 0) CurentHealth = 0;
        {
            UpdateHeal();
        }

        if(regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
        }
        regenCoroutine = StartCoroutine(HealthRegen());
    }
    
    IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(regenDelay);

        while(CurentHealth < PHealth)
        {
            CurentHealth += 1;
            UpdateHeal();
            yield return new WaitForSeconds(regenTickBack);
        }
    }
    void UpdateHeal()
    {
        PHealthbar.value = CurentHealth;

        if(CurentHealth >= PHealth)
        {
            healthbarOBJ.SetActive(false);            
        }
        else
        {
            healthbarOBJ.SetActive(true);
        }
    }
    private void Die()
    {
        Debug.Log("Player Die");
        Destroy(gameObject);
    }
}