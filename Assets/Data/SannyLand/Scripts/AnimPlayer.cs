using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(RigidbodyMove))]
public class AnimPlayer : MonoBehaviour
{
    private Animator animator2D;
    private Rigidbody2D rigbody2D;
    private SpriteRenderer spriteRenderer2D;
    private RigidbodyMove rigidbodyMove;

    [Header("Const")]
    private const string idleRun_VelosityX = nameof(idleRun_VelosityX);
    private const string anyJump_VelosityY = nameof(anyJump_VelosityY);
    private const string isGround = nameof(isGround);

    

    void Awake()
    {
        animator2D = GetComponent<Animator>();
        rigbody2D = GetComponent<Rigidbody2D>();        
        spriteRenderer2D = GetComponent<SpriteRenderer>();
        rigidbodyMove = GetComponent<RigidbodyMove>();
    }

    void Update()
    {
        FlipX();
        ChangeAnimation();        
    }

    private void ChangeAnimation()
    {
        animator2D.SetFloat(idleRun_VelosityX, Mathf.Abs(rigbody2D.linearVelocityX));
        animator2D.SetFloat(anyJump_VelosityY, rigbody2D.linearVelocityY);
        animator2D.SetBool(isGround, rigidbodyMove.GetIsGround());
    }
    private void FlipX()
    {
        if (rigidbodyMove.GetDirectionX() > 0)
            spriteRenderer2D.flipX = false;
        else if (rigidbodyMove.GetDirectionX() < 0)
            spriteRenderer2D.flipX = true;
    }
}
