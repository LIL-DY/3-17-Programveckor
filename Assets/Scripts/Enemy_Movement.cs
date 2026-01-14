using UnityEngine;

public class EnemyFollowWithAttack : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float agroRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        
        if (distance > agroRange)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        
        if (distance <= attackRange)
        {
            rb.linearVelocity = Vector2.zero;
            Attack();
            return;
        }

        
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            GetComponent<Enemy_Combat>().DealDamage(player.gameObject);
            lastAttackTime = Time.time;
        }
    }
}
