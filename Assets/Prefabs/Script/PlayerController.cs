using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementForce;
    public float JumpForce;
    public Animator PlayerAnimationController;


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
        TouchingObjects.Add(otherObject.name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
    }

}