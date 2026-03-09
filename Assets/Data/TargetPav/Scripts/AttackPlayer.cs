using UnityEngine;

public class AttackPlayer : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float distanse;
    [SerializeField] float damage;
    private Ray2D ray2D;
    private RaycastHit2D raycastHit2D;
    

    private void Update()
    {
        RayDrow();
    }

    private void RayDrow()
    {
        Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 player = new Vector2(transform.position.x, transform.position.y);
        ray2D = new Ray2D(player, mouse);

        Debug.DrawRay(player, mouse * distanse);
    }
    public void Attack()
    {
        raycastHit2D = Physics2D.Raycast(ray2D.origin, ray2D.direction, distanse);

        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.TryGetComponent(out IGiveDamage target))
        {
            TakeDamage(target);
        }
    }

    public void TakeDamage(IGiveDamage giveDamage)
    {
        giveDamage.GiveDamage(damage);
    }


}
