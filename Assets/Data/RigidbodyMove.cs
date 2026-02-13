using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class RigidbodyMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [Header("Horizontal Transform")]
    [SerializeField] private float speedGo = 3;
    private const string Horizontal = nameof(Horizontal);    
    private float directionX;

    [Header("Jump")]
    [SerializeField] private float speedJump = 6;
    [SerializeField] private float groundRadius = 0.1f;
    [SerializeField] private Transform groundCheck;
    private LayerMask groundLayer;    
    private KeyCode KeyJump = KeyCode.Space;
    private bool jumpPressed = false;
    private bool isGrounded = true;


    void Awake()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        directionX = Input.GetAxis(Horizontal);
        if (Input.GetKeyDown(KeyJump))
        {
            jumpPressed = true;
        }        
    }

    private void FixedUpdate()
    {
        //rigidbody2D.linearVelocity = 
        //    new Vector2(directionX * speed, rigidbody2D.linearVelocityY); - длинный вариант
      
        rigidbody2D.linearVelocityX = directionX * speedGo;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (jumpPressed && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
            //rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocityX, speedJump);
        }

        jumpPressed = false;
    }
}
