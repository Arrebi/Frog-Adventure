using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public bool Agressive = false;
    public float count = 0f;
    public int limitChangeStatus = 10;

    // componentes
    Animator Turtleanimator;

    // Start is called before the first frame update
    void Start()
    {
            Turtleanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        count += (1 * Time.deltaTime);


        if (count > limitChangeStatus)
        {
            count = 0;

            Agressive = !Agressive;

            // Modificar animacion
            Turtleanimator.SetBool("Agressive", Agressive);
        }
    }

    // Chequear colision con player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("contacto con el player");
        }
    }

}
