using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScannerManager : MonoBehaviour
{
    //Refrencing Text Mesh Pro 
    public TMPro.TMP_Text dataName;
    public TMPro.TMP_Text dataDescription;

    public Animator animator;



    //keep track of scanner sentences 
    private Queue<string> dataSentences;



    void Start()
    {
        dataSentences = new Queue<string>();

    }

    public void StartScanning(Scanning scanning)
    {
        animator.SetBool("IsOpen", true);

        dataName.text = scanning.dataName;

        //clear earlier sentences
        dataSentences.Clear();

        foreach (string sentence in scanning.dataSentences)
        {
            dataSentences.Enqueue(sentence);
        }

        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        //ending it if no more sentences left. 
        if (dataSentences.Count == 0)
        {
            EndScanning();
            return;
        }

        string sentence = dataSentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //let the sentence print out with a slight delay 
    IEnumerator TypeSentence(string sentence)
    {
        dataDescription.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dataDescription.text += letter;
            //wait frame
            yield return null;

        }
    }
    void EndScanning()
    {
        animator.SetBool("IsOpen", false);
    }

}
