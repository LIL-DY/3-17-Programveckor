using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        
        moveInput = moveInput.normalized;
    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
