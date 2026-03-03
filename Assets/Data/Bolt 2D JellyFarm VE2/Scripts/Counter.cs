using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] ViewText viewText;
    private int count = 0;
   
    public void AddCount()
    {
        count++;
        PrintText();
    }

    private void PrintText()
    {
        viewText.DrowText(count);
    }

    public int GetCounter()
    {
        return count;
    }
}
