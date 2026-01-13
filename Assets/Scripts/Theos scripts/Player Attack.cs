using System.Collections;
using UnityEngine;

public class PlayerAttackFinal : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 1f;
    public LayerMask enemyLayer;
    public float attackCooldown = 2f;
    private float lastAttckTime = 0f;

    private GameObject attackArea;
    private bool attacking = false;
    public float attackTime = 0.2f;
    private float timer = 0f;

    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryAttck();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if(timer >= attackTime)
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(false);
            }
        }
    }

    void TryAttck()
    {
        if(Time.time - lastAttckTime >= attackCooldown)
        {
            StartAttack();
            lastAttckTime = Time.time;
        }
    }

    void StartAttack()
    {
        attacking = true;
        timer = 0f;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = (mousePos - transform.position).normalized;
        Vector2 AttackPos = transform.position + new Vector3(Direction.x, Direction.y, 0) * attackRange;
        attackArea.transform.position = AttackPos;

        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        attackArea.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        attackArea.SetActive(true);
        Collider2D[] HittEnemies = Physics2D.OverlapBoxAll(attackArea.transform.position, attackArea.GetComponent<Collider2D>().bounds.size, 0f, enemyLayer);
        foreach(Collider2D enemy in HittEnemies)
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }
    }
}