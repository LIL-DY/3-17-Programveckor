using UnityEngine;

public class PlayerAttack3: MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;
    private float AttackTime = 0.25f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= AttackTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void StartAttack()
    {
        attacking = true;
        timer = 0f;
        attackArea.SetActive(true);
    }
}
