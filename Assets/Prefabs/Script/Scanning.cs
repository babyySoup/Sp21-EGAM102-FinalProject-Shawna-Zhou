using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scanning
    {
        // pass into the scanner manager.

        [TextArea(3, 15)]
        public string[] dataSentences;
        public string dataName;

    }
