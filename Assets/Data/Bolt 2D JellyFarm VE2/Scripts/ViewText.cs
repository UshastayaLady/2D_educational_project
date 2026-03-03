using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewText : MonoBehaviour
{
    [SerializeField] private Text text;

    public void DrowText(int forString)
    {
        text.text = Convert.ToString(forString);
    }
}
