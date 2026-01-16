using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 2.5f;
    public LayerMask enemyLayer;
    public Animator animator;

    public float attackCooldown = 1f;
    private float lastAttackTime = -999f;

    public AudioSource audioSource;
    public AudioClip MissingSound;
    public AudioClip[] hittingSound;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Välj vilka knappar du vill ha:
        bool pressed = Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.J);

        if (pressed)
            TryAttack();
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown)
            return;

        lastAttackTime = Time.time;

        // Spela animation (kräver Trigger "Attack" i Animator)
        if (animator != null)
            animator.SetTrigger("Attack");

        Attack();
    }

    void Attack()
    {
        bool hittingSomething = false;

        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        Debug.Log("Attack! Hits: " + hitEnemies.Length);

        foreach (Collider2D hit in hitEnemies)
        {
            Debug.Log("Hit: " + hit.name);

            var enemy = hit.GetComponent<MonsterHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                hittingSomething = true;
            }

            var plant = hit.GetComponent<BreakablePlant>();
            if (plant != null)
            {
                plant.TakeDamage(damage);
                hittingSomething = true;
            }
        }

        PlayAttackSound(hittingSomething);
    }



    void PlayAttackSound(bool hitEnemies)
    {
        if (hitEnemies)
        {
            int index = Random.Range(0, hittingSound.Length);
            audioSource.PlayOneShot(hittingSound[index]);
        }
        else
        {
            audioSource.PlayOneShot(MissingSound);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
