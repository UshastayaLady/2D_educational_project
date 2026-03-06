using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Bullet : InitPool
{
    private Rigidbody2D newRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float timeLive;
    [SerializeField] private float damage;

    void Start()
    {
        newRigidbody = GetComponent<Rigidbody2D>();
        newRigidbody.gravityScale = 0;
    }

    private void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(IKilled());       
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
        //if (collision != null && collision.gameObject.TryGetComponent<ITakeDamage>) 
        //{ 

        //}
    }

    private IEnumerator IKilled()
    {
        yield return new WaitForSeconds(timeLive);
        poolObject.PulObgectInPool(this.gameObject.GetComponent<SpriteRenderer>());
    }
}
