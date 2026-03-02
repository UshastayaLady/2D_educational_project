using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer obrazec;
    private List <SpriteRenderer>  poolObject;
    [SerializeField] private int cauntStart;

    private void Start()
    {
        poolObject = new List <SpriteRenderer>();
        StartInitializationPoolObject();
    }

    private void StartInitializationPoolObject()
    {
        for (int i = 0; i < cauntStart; i++)
        {
            poolObject.Add(Instantiate(obrazec, new Vector2(0f,0f), Quaternion.identity));
            poolObject[i].gameObject.SetActive(false);
        }        
    }

    private void AddPoolObject()
    {
        poolObject.Add(Instantiate(obrazec, new Vector2(0f, 0f), Quaternion.identity));
        poolObject[poolObject.Count-1].gameObject.SetActive(false);
    }

    public SpriteRenderer GetObgectInPool()
    {
        for (int i = 0; i < poolObject.Count; i++)
        {
            if (poolObject[i].gameObject.activeSelf == false)
                return poolObject[i];
        }

        AddPoolObject();
        return poolObject[poolObject.Count - 1];
    }

    public SpriteRenderer GetObgectInPool(Vector2 position, Quaternion quaternion)
    {
        for (int i = 0; i < poolObject.Count; i++)
        {
            if (poolObject[i].gameObject.activeSelf == false)
            {
                poolObject[i].transform.position = position;
                poolObject[i].transform.rotation = quaternion;
                return poolObject[i];
            }               
        }

        AddPoolObject();
        poolObject[poolObject.Count - 1].transform.position = position;
        poolObject[poolObject.Count - 1].transform.rotation = quaternion;
        return poolObject[poolObject.Count - 1];
    }
}
