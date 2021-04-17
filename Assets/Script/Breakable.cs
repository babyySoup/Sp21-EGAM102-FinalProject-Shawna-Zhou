using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    private ParticleSystem particle;
    private SpriteRenderer sr;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerController>() &&
            other.contacts[0].normal.y > 0.5f)
        {
            StartCoroutine(Break());
        }
    }

    //give time to particles to come out
    private IEnumerator Break()
    {
        particle.Play();
        //turn off sprite when hit
        sr.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
