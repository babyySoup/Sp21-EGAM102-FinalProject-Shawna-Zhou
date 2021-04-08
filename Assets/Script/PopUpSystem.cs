using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//california 
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    //dialogue 
    public GameObject dialogueBox;
    public Animator boxAnimator;
    //pasadena 
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        dialogueBox.SetActive(true);
        popUpText.text = text;
        boxAnimator.SetTrigger("popUp");
    }
}
