using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    [HideInInspector]
    public bool isFirstInWave = false;

    [Header("Attack")]
    public float attackRange = 0.8f;
    public int damage = 10;
    public float attackCooldown = 1.0f;

    [Header("Audio")]
    public AudioClip walkingClip;
    public AudioClip screamClip;
    private AudioSource walkingScource;
    private AudioSource screamScource;
    

    Transform player;
    Health playerHealth;
    Rigidbody2D rb;

    float nextAttackTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource[]sources = GetComponents<AudioSource>();
        walkingScource = sources[0];
        screamScource = sources[1];
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("Hittar ingen Player med tag 'Player'. Tagga din Player!");
            enabled = false;
            return;
        }

        player = playerObj.transform;
        playerHealth = playerObj.GetComponent<Health>();

        if (playerHealth == null)
            Debug.LogError("Player saknar PlayerHealth script!");

        walkingScource.clip = walkingClip;
        walkingScource.loop = true;
        walkingScource.playOnAwake = false;
        walkingScource.volume = 0.1f;

        screamScource.clip = screamClip;
        screamScource.loop = false;
        screamScource.playOnAwake = false;
        screamScource.volume = 0.7f;

        if (isFirstInWave)
        {
            screamScource.Play();
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

       
        if (dist > attackRange)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);

            if (!walkingScource.isPlaying)
                walkingScource.Play();
        }
        else
        {

            if (walkingScource.isPlaying)
                walkingScource.Stop();

            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackCooldown;

                if (playerHealth != null)
                    playerHealth.TakeDamage(damage);
            }
        }
    }
}
