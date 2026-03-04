using UnityEngine;


[RequireComponent (typeof (PoolObject))] 
public class SpawEnemy : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform centr;
    private Vector2 SpawnPosition;
    private SpriteRenderer enemyObject;
    private PoolObject poolObject;  
   

    void Start()
    {
        poolObject = GetComponent<PoolObject>();
    }

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        SpawnPosition = (Vector2)centr.position + Random.insideUnitCircle.normalized * radius;
        enemyObject = poolObject.GetObgectInPool(SpawnPosition, Quaternion.identity);
        enemyObject.gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
