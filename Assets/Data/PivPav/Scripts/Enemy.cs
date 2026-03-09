using UnityEngine;

[RequireComponent(typeof(FindPool))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(FindPool))]
public class Enemy : MonoBehaviour, IGiveDamage
{
    [SerializeField] private float hp;
    private FindPool findPool;

    private void Awake()
    {
        findPool = GetComponent<FindPool>();
    }

    public void GiveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            findPool.EventGo();
        }
    }
}
