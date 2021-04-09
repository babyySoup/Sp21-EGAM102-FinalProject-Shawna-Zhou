using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue 
{
    // pass into the dialogue manager.

    [TextArea(3,15)]
    public string[] sentences;
    public string name;
    
}
