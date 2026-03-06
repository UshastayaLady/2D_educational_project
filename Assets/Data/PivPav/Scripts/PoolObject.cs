using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private SpriteRenderer obrazec;
    private Queue <SpriteRenderer>  poolObject;
    [SerializeField] private int cauntStart;

    private void Awake()
    {
        poolObject = new Queue<SpriteRenderer>();
        StartInitializationPoolObject();
    }

    private void StartInitializationPoolObject()
    {
        for (int i = 0; i < cauntStart; i++)
        {
            AddPoolObject();
        }        
    }

    private void AddPoolObject()
    {
        AddPoolObject(Instantiate(obrazec, new Vector2(0f, 0f), Quaternion.identity));
    }

    private void AddPoolObject(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.transform.SetParent(container);
        if (spriteRenderer.TryGetComponent<FindPool>(out FindPool find))
        {
            find.SetPoolObject(this);
        }
        spriteRenderer.gameObject.SetActive(false);
        poolObject.Enqueue(spriteRenderer);
    }

    public SpriteRenderer GetObgectInPool()
    {
        if (poolObject.Count == 0)
            AddPoolObject();
        return poolObject.Dequeue();
    }

    public SpriteRenderer GetObgectInPool(Vector2 position, Quaternion quaternion)
    {         
        SpriteRenderer forWorkItem = GetObgectInPool();
        forWorkItem.transform.position = position;
        forWorkItem.transform.rotation = quaternion;
        return forWorkItem;
    }
    public void PulObgectInPool(SpriteRenderer spriteRenderer)
    {        
        AddPoolObject(spriteRenderer);
    }
}
