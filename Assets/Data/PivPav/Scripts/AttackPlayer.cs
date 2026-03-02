using UnityEngine;

[RequireComponent (typeof (PoolObject))]
public class AttackPlaier : MonoBehaviour
{
    [SerializeField] private KeyCode keyCodeFire = KeyCode.Mouse0;
    private PoolObject poolObject;
    private SpriteRenderer bullet;
    [SerializeField] private Transform transformFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        poolObject = GetComponent<PoolObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Atttak();
    }
    private void Atttak()
    {
        if (Input.GetKeyDown(keyCodeFire))
        {
            bullet = poolObject.GetObgectInPool();
            bullet.transform.position = transformFire.position;
            bullet.transform.rotation = transformFire.rotation;
            bullet.gameObject.SetActive(true);
        }
    }
}
