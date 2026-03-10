using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FindPool))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof (Rigidbody2D))]

public class Bullet : MonoBehaviour, IGiveDamage
{
    private Rigidbody2D newRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timeLive;
    private FindPool findPool;
    private Coroutine lifeCoroutine;

    void Awake()
    {
        findPool = GetComponent<FindPool>();
        newRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {        
        newRigidbody.gravityScale = 0;
    }

    private void OnEnable()
    {
        if (lifeCoroutine != null)
            StopCoroutine(lifeCoroutine);
        lifeCoroutine = StartCoroutine(IKilled());
    }
    private void OnDisable()
    {
        if (lifeCoroutine != null)
        {
            StopCoroutine(lifeCoroutine);
            lifeCoroutine = null;
        }
    }

    void Update()
    {
        Move();        
    }

    private void Move()
    {        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
        {
            GiveDamage(takeDamage);
            findPool.EventGo();
        }
    }
    private IEnumerator IKilled()
    {
        yield return new WaitForSeconds(timeLive);
        findPool.EventGo();
    }

    public void GiveDamage(ITakeDamage takeDamage)
    {
        takeDamage.TakeDamage(damage);
        findPool.EventGo();
    }    
}
