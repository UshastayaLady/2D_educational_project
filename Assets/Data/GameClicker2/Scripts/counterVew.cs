using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Counter2))]
public class counterVew : MonoBehaviour
{
    [SerializeField] private Text textCounter;
    private Counter2 counter;
    private void Awake()
    {
        counter = GetComponent<Counter2>();
    }
    private void OnEnable()
    {
        counter.AddedCounter += WriteViewCounter;
    }

    private void OnDisable()
    {
        counter.AddedCounter -= WriteViewCounter;
    }

    private void WriteViewCounter(int count)
    {
        textCounter.text = count.ToString();
    }
}
