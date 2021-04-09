using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //Refrencing Text Mesh Pro 
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueBoxText;

    public Animator animator; 




    //keep track of sentences 
    private Queue<string> sentences; 
     
    
    
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartConversation (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueBoxText.text = ""
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBoxText.text += letter;
            //wait frame
            yield return null; 

        }
    }
    void EndConversation()
    {
        animator.SetBool("IsOpen", false);
    }

}
