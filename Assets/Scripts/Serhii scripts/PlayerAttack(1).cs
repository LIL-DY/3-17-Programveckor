using UnityEngine;

public class PlayerAttackHeavy : MonoBehaviour
{
    [Header("Heavy Attack Settings")]
    public int damage = 2;
    public float attackRange = 1.2f;
    public LayerMask enemyLayer;

    public float attackCooldown = 1.5f;
    private float lastAttackTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TryHeavyAttack();
        }
    }

    void TryHeavyAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            HeavyAttack();
            lastAttackTime = Time.time;
        }
    }

    void HeavyAttack()
    {
        
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange,
            enemyLayer
        );

        if (enemies.Length == 0)
            return;

        
        Collider2D nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < nearestDistance)
            {
                nearestDistance = dist;
                nearestEnemy = enemy;
            }
        }

        
        if (nearestEnemy != null)
        {
            EnemyHealth hp = nearestEnemy.GetComponent<EnemyHealth>();
            if (hp != null)
                hp.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
