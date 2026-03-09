using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PoolObject))]
public class SpawnTarget : MonoBehaviour
{
    PoolObject poolObject;
    [SerializeField] Transform[] targetPoints;    
    [SerializeField] private float timeReSpawn;

    private Dictionary<Vector2, Target> activeTargets = new Dictionary<Vector2, Target>();

    void Awake()
    {
        poolObject = GetComponent<PoolObject>();
    }
    void Start()
    {
        for (int i = 0; i < targetPoints.Length; i++)
        {
            SpawnTargetAtPoint(new Vector2(targetPoints[i].transform.position.x, targetPoints[i].transform.position.y));
        }
    }

    private void SpawnTargetAtPoint(Vector2 point)
    {
        if (activeTargets.ContainsKey(point) && activeTargets[point] != null)
        {            
            return;
        }

        FindPool findPool = poolObject.GetObgectInPool();
        findPool.transform.position = new Vector2(point.x, point.y);
        findPool.gameObject.SetActive(true);


        if (findPool.TryGetComponent(out Target target))
        {
            activeTargets[point] = target;

            target.OnTargetDestroyed += (destroyedTarget) => OnTargetDestroyed(point);

        }
        else
        {
            Debug.LogError("Target component not found on pooled object!");
        }
    }

    private void OnTargetDestroyed(Vector2 point)
    {
        Debug.Log($"Target destroyed at {point}, respawning in {timeReSpawn} seconds");

        if (activeTargets.ContainsKey(point))
        {
            activeTargets.Remove(point);
        }

        StartCoroutine(RespawnCoroutine(point));
    }


    private IEnumerator RespawnCoroutine(Vector2 point)
    {
        yield return new WaitForSeconds(timeReSpawn);
        SpawnTargetAtPoint(point);
    }
}
