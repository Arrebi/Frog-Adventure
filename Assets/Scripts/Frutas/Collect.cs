using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Collected", true);
        }
    }

    void DestroyFruit()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
