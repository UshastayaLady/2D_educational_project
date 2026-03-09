//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//[RequireComponent (typeof (PoolObject))]
//public class RandTals: MonoBehaviour
//{
//    /*
//    Реализовать спавн блока с травой на верхнем уровне карты
//    + реализовать рандомное смещения высоты карты в (-1,0,+1) уровне, тоесть или снижается, или остается прежднем, или повышается.
//    в ответ прислать только скрипт! 
//     */

//    [SerializeField] private List<Sprite> tals = new List<Sprite>();
//    [SerializeField] private Sprite talsHight;
//    [SerializeField] private int currentHeight;
//    private PoolObject poolObject;

//    private void Start()
//    {        
//        poolObject = GetComponent<PoolObject>();
//        CreateWorld();
//    }

//    private SpriteRenderer GetRandTal()
//    {
//        SpriteRenderer talForWork;        
//        talForWork = poolObject.GetObgectInPool();
//        talForWork.GetComponent<SpriteRenderer>().sprite = tals.ElementAt(Random.Range(0, tals.Count-1));
//        return talForWork;
//    }

//    private SpriteRenderer GetRandTal(Sprite talsHight)
//    {
//        SpriteRenderer talForWork;
//        talForWork = poolObject.GetObgectInPool();
//        talForWork.GetComponent<SpriteRenderer>().sprite = talsHight;
//        return talForWork;
//    }

//    private void CreateWorld()
//    {
//        Vector2 startPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
//        SpriteRenderer talForWork = null;
//        for (; startPoint.x < Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;)
//        {
//            int newCount = Random.Range(currentHeight-1, currentHeight + 2);
//            if (newCount < 1) newCount = 1; // Проверка для дурака, у нас не может отсутсвовать земля
            
//            float startPointY = startPoint.y;
//            for (int l = 0; l < newCount; l++)
//            {
//                talForWork = (newCount - 1 == l) ? GetRandTal(talsHight) : GetRandTal();   
//                talForWork.gameObject.transform.position = new Vector2(startPoint.x + talForWork.transform.localScale.x/2, startPoint.y + talForWork.transform.localScale.y / 2);
//                talForWork.gameObject.SetActive(true);
//                startPoint = new Vector2 (startPoint.x, startPoint.y + talForWork.transform.localScale.y);
//            }
//            if(talForWork!=null)
//                startPoint = new Vector2(startPoint.x + talForWork.transform.localScale.x, startPointY);
//        }
//    }
//}
