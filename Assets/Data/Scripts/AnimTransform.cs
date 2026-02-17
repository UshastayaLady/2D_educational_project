using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TransformMove))]
public class AnimTransform : MonoBehaviour
{
    
    private Animator animator2D;
    private TransformMove transformMove;
    [Header("Const")]
    private const string idleRun_VelosityX = nameof(idleRun_VelosityX);
    private const string anyJump_VelosityY = nameof(anyJump_VelosityY);
    private const string isGround = nameof(isGround);
    private const string isAttack = nameof(isAttack);



    void Awake()
    {
        animator2D = GetComponent<Animator>();
        transformMove = GetComponent<TransformMove>();
    }

    void Update()
    {
        FlipX();
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(transformMove.GetDirectionX()) > 0)
            animator2D.SetFloat(idleRun_VelosityX, Mathf.Abs(transformMove.GetDirectionX())-0.5f);
        
        else if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(transformMove.GetDirectionX()) > 0)
            animator2D.SetFloat(idleRun_VelosityX, Mathf.Abs(transformMove.GetDirectionX()));
        
        animator2D.SetBool(isGround, transformMove.GetIsGround());

        if (Input.GetMouseButtonDown(0))
        {
            animator2D.SetBool(isAttack, true);           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator2D.SetBool(isAttack, false);
        }

    }
    private void FlipX()
    {
        if (transformMove.GetDirectionX() > 0)
            animator2D.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        else if (transformMove.GetDirectionX() < 0)
            animator2D.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
    }
}