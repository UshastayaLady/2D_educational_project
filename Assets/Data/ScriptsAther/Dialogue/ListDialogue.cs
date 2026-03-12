using System.Collections.Generic;
using UnityEngine;

public class ListDialogue : MonoBehaviour
{
    [SerializeField] List<TextAsset> dealogues = new List<TextAsset>();
    private InstantiateDialogue iInstantiateDialogue;
    private DialogueManager dialogueManager;
    private int indexTA;

    private void Awake()
    {
        iInstantiateDialogue = FindAnyObjectByType<InstantiateDialogue>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }
    private void OnEnable()
    {
        iInstantiateDialogue.NextDialogue += NextIndexDialogue;
    }
    private void SendAndStartDialogue()
    {
        dialogueManager.OpenWindos(dealogues[indexTA]);
    }

    private void NextIndexDialogue(int index)
    {
        if (index == -1)
            indexTA++;
        else indexTA = index;
    }

    private void OnDisable()
    {
        iInstantiateDialogue.NextDialogue -= NextIndexDialogue;
    }

}
