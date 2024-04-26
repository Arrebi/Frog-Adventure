using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enSuelo : MonoBehaviour
{
    public static bool verificador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        verificador = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        verificador = false;
    }
}
