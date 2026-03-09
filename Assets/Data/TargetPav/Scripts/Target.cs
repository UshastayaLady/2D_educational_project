//using UnityEngine;

//public class Target : MonoBehaviour, IGiveDamage
//{
//    [SerializeField] private float hp;
//    private FindPool findPool;
//    private void Awake()
//    {
//        findPool = GetComponent<FindPool>();
//    }

//    public void GiveDamage(float damage)
//    {
//        if (hp > 0)
//        {
//            hp -= damage;
//        }
//        else
//        {
//            poolObject.PutObgectInPool(this.findPool);
//        }
//    }
//}
