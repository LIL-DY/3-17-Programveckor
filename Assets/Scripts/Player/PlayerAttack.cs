using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    public float attackCooldown = 1f; 
    private float lastAttackTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time; 
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
