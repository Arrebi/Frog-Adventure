using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 4;
    public int score = 0;
    float horizontal;

    Rigidbody2D rb;
    Animator Playeranim;
    SpriteRenderer sp;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;
    public float lowJumpMiltiplier = 1f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Playeranim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        horizontal = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si sube o baja
        Playeranim.SetFloat("Falling", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);

            sp.flipX = false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);

            // rotar imagen
            sp.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && enSuelo.verificador)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);    
        }

        if(betterJump)
        {
            if(rb.velocity.y  < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier) * Time.deltaTime;
            }
            if(rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMiltiplier) * Time.deltaTime;
            }
        }

        // Animacion de caminar
        if ((Input.GetKey("d") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("left")))
        {
            Playeranim.SetBool("isMoving", true);
        }
        else
        {
            Playeranim.SetBool("isMoving", false);
        }
        // Animacion salto
        if (enSuelo.verificador)
        {
            Playeranim.SetBool("inGround", true);

        }
        else
        {
            Playeranim.SetBool("inGround", false);
            Playeranim.SetBool("isMoving", false);
        }
    }

}
