using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MovementForce;
    public float JumpForce;
    public Animator PlayerAnimationController;
    public List<string> InRangeObjects;

    //dialogue triggers 
    public DialogueTrigger ARiDialogue;
    public DialogueTrigger HeelDialogue;
    public DialogueTrigger TrashcanDialogue;

    //Cliff triggers
    public DialogueTrigger ZachDialogue;
    public DialogueTrigger JazDialogue;
    public DialogueTrigger StreetLightDialogue;

    //PizzaScene triggers
    public DialogueTrigger CatDialogue;
    public DialogueTrigger PizzaDialogue;



    void Start()
    {
        InRangeObjects = new List<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D thisrigidbody2D;
            thisrigidbody2D = GetComponent<Rigidbody2D>();
            thisrigidbody2D.AddForce(JumpForce * Vector3.up, ForceMode2D.Impulse);
        }

        //walk and rest animation, when D is pressed the animation Walk plays
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerAnimationController.SetTrigger("Walk");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnimationController.SetTrigger("Rest");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerAnimationController.SetTrigger("WalkL");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnimationController.SetTrigger("Rest");
        }
    }



    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            Rigidbody2D thisrigidbody2D;
            thisrigidbody2D = GetComponent<Rigidbody2D>();
            thisrigidbody2D.AddForce(MovementForce * Vector3.right, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody2D thisrigidbody2D;
            thisrigidbody2D = GetComponent<Rigidbody2D>();
            thisrigidbody2D.AddForce(MovementForce * Vector3.left, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        InRangeObjects.Add(collider.name);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        InRangeObjects.Remove(collider.name);
    }


    public void decideDialogue()
    {
        if (InRangeObjects.Contains("ARi"))
        {
            ARiDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Cat"))
        {
            CatDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Zachary"))
        {
            ZachDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Jazmine"))
        {
            JazDialogue.TriggerDialogue();
        }
    }

    
    public void decideExamine()
    {
        if (InRangeObjects.Contains("Heel"))
        {
            HeelDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Trashcan"))
        {
            TrashcanDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Pizza"))
        {
            PizzaDialogue.TriggerDialogue();
        }
        else if (InRangeObjects.Contains("Streetlight"))
        {
            StreetLightDialogue.TriggerDialogue();
        }
    }
}