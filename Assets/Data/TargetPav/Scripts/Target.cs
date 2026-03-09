using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(FindPool))]
public class Target : MonoBehaviour, IGiveDamage
{
    [SerializeField] private float hp;
    private float maxHp;
    private FindPool findPool;
    public event Action<Target> OnTargetDestroyed;
      

    private void Awake()
    {
        findPool = GetComponent<FindPool>();
        maxHp = hp;
    }
    private void OnEnable()
    {
        hp = maxHp;
    }

    public void GiveDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
        else
        {
            OnTargetDestroyed?.Invoke(this);
            findPool.EventGo();
        }
    }
}
