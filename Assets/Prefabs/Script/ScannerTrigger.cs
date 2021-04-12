using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTrigger : MonoBehaviour
{
    public Scanning scanning;

    public void TriggerScanning()
    {
        FindObjectOfType<ScannerManager>().StartScanning(scanning);
    }
}
