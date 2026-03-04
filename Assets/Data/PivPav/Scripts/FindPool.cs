using UnityEngine;

public class FindPool : MonoBehaviour
{
    private PoolObject poolObject;

    public void SetPoolObject(PoolObject poolObject)
    {
        this.poolObject = poolObject;
    }

    public PoolObject GetPoolObject()
    {
        return poolObject;
    }

}
