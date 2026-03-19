using System;
using UnityEngine;

[RequireComponent(typeof(Clicker2))]
public class Counter2 : MonoBehaviour
{
    private Clicker2 clicker;
    private int count = 0;
    public event Action<int> AddedCounter;
    
    private void Awake()
    {
        clicker = GetComponent<Clicker2>();
    }
    private void OnEnable()
    {
        clicker.OnClicked += AddCounter;
    }

    private void OnDisable()
    {
        clicker.OnClicked += AddCounter;
    }
    private void AddCounter(int price)
    {
        count += price;
        AddedCounter?.Invoke(count);
    }
}
