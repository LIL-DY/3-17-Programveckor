using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;

    public AudioSource PlayerFootStep;
    public float whenToPlaySound = 0.3f;
    private float StepTimer = 0f;
   

    

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender =GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        
        if(movement != Vector2.zero)
        {
            StepTimer += Time.deltaTime;
            if(StepTimer >= whenToPlaySound)
            {
                PlayerFootStep.Play();
                StepTimer = 0f; 
            }
        }
        else
        {
            StepTimer = 0f;
            if (PlayerFootStep.isPlaying)
            {
                PlayerFootStep.Stop();
            }
        }

        
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() 
    {
        movement = playerControls.Movment.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = false;
        }
        else
        {
            mySpriteRender.flipX = true;
        }
    }
}
