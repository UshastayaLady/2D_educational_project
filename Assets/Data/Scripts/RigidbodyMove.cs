using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class RigidbodyMove : MonoBehaviour
{
    private Rigidbody2D rigbody2D;
    private SpriteRenderer spriteRenderer2D;
    private Animator animator2D;

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

    [Header("Animator")]
    private const string idleRun_VelosityX = nameof(idleRun_VelosityX);
    private const string anyJump_VelosityY = nameof(anyJump_VelosityY);


    void Awake()
    {
        rigbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer2D = GetComponent<SpriteRenderer>();
        animator2D = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        DownButton();
        ChangeAnimation();
    }
    private void DownButton()
    {
        directionX = Input.GetAxis(Horizontal);
        if (Input.GetKeyDown(KeyJump))
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        FlipX();
        Jump();       
    }
    private void Move()
    {
        //rigidbody2D.linearVelocity = 
        //    new Vector2(directionX * speed, rigidbody2D.linearVelocityY); - длинный вариант

        rigbody2D.linearVelocityX = directionX * speedGo;       
    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (jumpPressed && isGrounded)
        {
            rigbody2D.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
            //rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocityX, speedJump);
        }

        jumpPressed = false;
    }

    private void ChangeAnimation()
    {
        if (rigbody2D.linearVelocityX == 0)
        {
            animator2D.SetFloat(idleRun_VelosityX, -1);
        }
        else
        {
            animator2D.SetFloat(idleRun_VelosityX, 1);
        }

        if (rigbody2D.linearVelocityY < 0)
        {
            animator2D.SetFloat(anyJump_VelosityY, -1);
        }
        else if (rigbody2D.linearVelocityY > 0)
        {
            animator2D.SetFloat(anyJump_VelosityY, 1);
        }
        else 
        {
            animator2D.SetFloat(anyJump_VelosityY, 0);
        }
    }

    private void FlipX()
    {
        if (directionX < 0)
        {
            spriteRenderer2D.flipX = true;
        }
        else if (directionX > 0)
        {
            spriteRenderer2D.flipX = false;
        }
    }
}
