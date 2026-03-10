using UnityEngine;

[RequireComponent(typeof(FindPool))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(FindPool))]
public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float hp;
    private FindPool findPool;

    private void Awake()
    {
        findPool = GetComponent<FindPool>();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            findPool.EventGo();
        }
    }
}
