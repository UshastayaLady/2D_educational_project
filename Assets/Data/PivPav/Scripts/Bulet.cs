using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Bulet : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float timeLive;
    [SerializeField] private float damage;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;        
    }

    private void OnEnable()
    {
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
        gameObject.SetActive(false);
    }
}
