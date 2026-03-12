using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class InstantiateDialogue : MonoBehaviour
{
    #region variables

    [SerializeField] private ReadXmlDialogue xmlDialogue;

    public event Action<string> NpsText;
    public event Action<string, int> Answer;
    public event Action finish;
    public event Action finishNextDialogue;

    [SerializeField] private TextAsset ta;
    private int currentNode = 0;

    #endregion

    #region 
    void Start()
    {
        xmlDialogue = new ReadXmlDialogue();
        xmlDialogue = null;
        
    }
    private void OnEnable()
    {
        AnswerClick.answerClick += OnAnswerClicked;
    }
    public void StartDialogue()
    {
        if (ta!=null)
        {
            xmlDialogue = null;
            xmlDialogue = ReadXmlDialogue.Load(ta);
            currentNode = 0;            
            WriteText();
        }                   
    }        
   
    private void WriteText()
    {        
        NpsText?.Invoke(xmlDialogue.nodes[currentNode].npcText);
        for (int j = 0; j < xmlDialogue.nodes[currentNode].answers.Length; j++)
        {
            Answer?.Invoke(xmlDialogue.nodes[currentNode].answers[j].text, j);
            // события на добавление ответа
        }
    }

    #endregion
    private void OnAnswerClicked(int numberOfButton)
    {
        StartCoroutine(AnswerClicked(numberOfButton));
    }

    private IEnumerator AnswerClicked(int numberOfButton)
    {
        if (xmlDialogue.nodes[currentNode].answers[numberOfButton].endRestart == "true")
        {
            // метод закрытия окна
            finish?.Invoke();
            CloseDialogue();
            yield return new WaitForSeconds(2f);
        }
        else if (xmlDialogue.nodes[currentNode].answers[numberOfButton].endNextDialogue == "true")
        {
            // метод закрытия окна переход на следющий диалог
            finishNextDialogue?.Invoke();
            CloseDialogue();
            yield return new WaitForSeconds(2f);
        }
        else
        {
            currentNode = xmlDialogue.nodes[currentNode].answers[numberOfButton].nextNode;
            WriteText();
        }
    }  

    //окончание диалога
    public void CloseDialogue()
    {
        if (xmlDialogue != null)
        {
            xmlDialogue = null;
        }
        //deleteDialogue();
        currentNode = 0; // Начинаем с первого узла
    }

    private void OnDisable()
    {
        AnswerClick.answerClick -= OnAnswerClicked;
    }

}