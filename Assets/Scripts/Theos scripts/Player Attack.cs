using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attckArea = default;

    private bool attacking = false;
    private float AttackTime = 0.25f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attckArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= AttackTime)
            {
                timer = 0;
                attacking = false;
                attckArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attckArea.SetActive(attacking);
    }
}
