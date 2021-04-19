using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public string SceneName; 
    //collider scene switcher
    void OnTriggerEnter2D(Collider2D things)
    {
        if (things.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
