using System.Collections;
using UnityEngine;

public class AttackPlayer : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float distanse;
    [SerializeField] float pauseAttack;
    [SerializeField] float damage;
    private Ray2D ray2D;
    private RaycastHit2D raycastHit2D;
    private bool canAttack = true;



    private void Update()
    {
        RayDrow();
    }

    private void RayDrow()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 player = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (mouse - player).normalized;
        ray2D = new Ray2D(player, direction);

        Debug.DrawRay(player, direction * distanse);
    }
    public void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            raycastHit2D = Physics2D.Raycast(ray2D.origin, ray2D.direction, distanse);

            if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.TryGetComponent(out Target target))
            {
                Debug.Log(raycastHit2D.collider.gameObject.name);
                TakeDamage(target);
            }
            else if (raycastHit2D.collider != null)
            {
                Debug.Log(raycastHit2D.collider.gameObject.name);
            }
            
            StartCoroutine(CanAttack());
        }        
    }

    public void TakeDamage(IGiveDamage giveDamage)
    {
        giveDamage.GiveDamage(damage);
    }

    private IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(pauseAttack); 
        canAttack = true;
    }
}
