using UnityEngine;
using System.Collections;


[RequireComponent (typeof (PoolObject))] 
public class SpawEnemy : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform centr;
    [SerializeField] private float timeSpawn;
    private Vector2 SpawnPosition;
    private FindPool enemyObject;
    private PoolObject poolObject;  
   

    void Start()
    {
        poolObject = GetComponent<PoolObject>();
        StartCoroutine(SpawmCoroutine());
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

    private IEnumerator SpawmCoroutine()
    {
        while (enabled)
        {
            Spawn();
            yield return new WaitForSeconds(timeSpawn);
        }       
    }
}
