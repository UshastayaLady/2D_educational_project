using System;
using System.Collections;
using UnityEngine;


public class InstantiateDialogue : MonoBehaviour
{
    #region variables

    [SerializeField] private ReadXmlDialogue xmlDialogue;

    public event Action<string> NpsText;
    public event Action<string, int> Answer;
    public event Action<int> NextDialogue;
    public event Action Finish;    

    [SerializeField] private TextAsset ta;
    private int currentNode = 0;

    #endregion
    
    private void OnEnable()
    {
        AnswerClick.answerClick += OnAnswerClicked;
    }   

    public void StartDialogue(TextAsset textAsset)
    {
        if (ta!=null)
        {            
            CleanDialogue();
            ta = textAsset;
            xmlDialogue = ReadXmlDialogue.Load(ta);                      
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

    private void OnAnswerClicked(int numberOfButton)
    {
        StartCoroutine(AnswerClicked(numberOfButton));
    }

    private IEnumerator AnswerClicked(int numberOfButton)
    {
        var answer = xmlDialogue.nodes[currentNode].answers[numberOfButton];

        if (answer == null || answer.endRestart == "true")
        {
            Finish?.Invoke();
            CleanDialogue();

            if (answer.nextDialogue != null)
                NextDialogue?.Invoke(answer.nextDialogue.nextNumberDialogue);
            else NextDialogue?.Invoke(-1);
        }
        else
        {
            currentNode = answer.nextNode;
            WriteText();
        }

        yield return new WaitForSeconds(1f);
    }  

    private void CleanDialogue()
    {
        if (xmlDialogue != null)
            xmlDialogue = null;

        currentNode = 0;
    }

    private void OnDisable()
    {
        AnswerClick.answerClick -= OnAnswerClicked;
    }

}