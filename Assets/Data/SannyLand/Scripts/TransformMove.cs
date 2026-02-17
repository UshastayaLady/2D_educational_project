using UnityEngine;

public class TransformMove : MonoBehaviour
{
    [Header("Horizontal Transform")]
    [SerializeField] private float speedGo = 6;
    private const string Horizontal = nameof(Horizontal);
    private float directionX;

    [Header("Jump")]
    [SerializeField] private float forseJump = 2.5f;
    private const float Gravitation = 9.81f;
    private float velosityY;
    private float positionY;
    private KeyCode KeyJump = KeyCode.Space;

    [Header("Fall")]
    [SerializeField] private float groundDistans = 0.01f;
    [SerializeField] private float groundRaycastDistans = 0.3f;
    [SerializeField] private Transform groundCheck;
    private float normalGround = 0.9f;
    private RaycastHit2D raycastDown;
    private LayerMask groundLayer;
    private bool isGrounded = false;

    void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        positionY = transform.position.y;
    }

    void Update()
    {
        MoveTransform();
        CheckVelosityY();
    }

    private void MoveTransform()
    {
        directionX = Input.GetAxis(Horizontal);
        transform.position = new Vector3(transform.position.x + directionX * speedGo * Time.deltaTime, transform.position.y, transform.position.z);

    }

    private void JumpTransform()
    {        
        if (Input.GetKeyDown(KeyJump) && isGrounded)
        {
            velosityY += Mathf.Sqrt(2f * forseJump * Gravitation);
            isGrounded = false;            
        }        
    }
    private void CheckVelosityY()
    {
        CheckGround();
        JumpTransform();
        TransformDown();
        positionY += velosityY * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);        
    }

    private void TransformDown()
    {
        if (!isGrounded)
        {
            velosityY -= Gravitation * Time.deltaTime;
        }
        else
        {
            if (velosityY < 0f)
                velosityY = 0f;
        }
    }
    private void CheckGround()
    {
        raycastDown = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, groundRaycastDistans, groundLayer);
        if (raycastDown.collider != null)
        {            
            if (raycastDown.distance > groundDistans || raycastDown.normal.y < normalGround)
            {
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
            }
        }
        else            
        {
            isGrounded = false;
        }
    }
}
