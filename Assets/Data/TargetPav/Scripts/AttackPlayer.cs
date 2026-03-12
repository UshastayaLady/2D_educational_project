using System.Collections;
using UnityEngine;

public class AttackPlayer : MonoBehaviour, IGiveDamage
{
    [SerializeField] private float distanse;
    [SerializeField] float pauseAttack;
    [SerializeField] float damage;
    [SerializeField] Transform startPoinRay;
    private Ray2D ray2D;
    private RaycastHit2D raycastHit2D;
    private bool canAttack = true;

    private void RayDrow()
    {
        Vector2 player = new Vector2(startPoinRay.transform.position.x, startPoinRay.transform.position.y);
        ray2D = new Ray2D(player, Vector2.up);

        Debug.DrawRay(player, Vector2.up * distanse);
    }
    public void Attack()
    {
        if (canAttack)
        {
            RayDrow();
            canAttack = false;
            raycastHit2D = Physics2D.Raycast(ray2D.origin, ray2D.direction, distanse);

            if (raycastHit2D.collider != null)
            {
                if (raycastHit2D.collider.gameObject.TryGetComponent(out ITakeDamage target))
                {
                    GiveDamage(target);
                }
            }            
            
            StartCoroutine(CanAttack());
        }        
    }

    public void GiveDamage(ITakeDamage takeDamage)
    {
        takeDamage.TakeDamage(damage);
    }

    private IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(pauseAttack); 
        canAttack = true;
    }
}
