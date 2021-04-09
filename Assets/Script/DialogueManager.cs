using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //UI stuff
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueBoxText;
    
    
    //keep track of sentences 
    private Queue<string> sentences; 
     
    
    
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartConversation (Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        //clear earlier sentences
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ShowNextSentence();
    } 

    public void ShowNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueBoxText.text = sentence; 
    }

    void EndConversation()
    {
        Debug.Log("Nothing else to talk about...");
    }

}
