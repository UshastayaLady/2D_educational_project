using UnityEngine;

[RequireComponent (typeof (PoolObject))]
public class AttackPlaier : MonoBehaviour
{
    [SerializeField] private KeyCode keyCodeFire = KeyCode.Mouse0;
    private PoolObject poolObject;
    private FindPool bullet;
    [SerializeField] private Transform transformFire;

    void Awake()
    {
        poolObject = GetComponent<PoolObject>();
    }

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
