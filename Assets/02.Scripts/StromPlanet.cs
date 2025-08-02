using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StromPlanet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteo"))
        {
            GravityToCenter meteo = collision.GetComponent<GravityToCenter>();
            meteo.moveSpeed -= 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteo"))
        {
            GravityToCenter meteo = collision.GetComponent<GravityToCenter>();
            meteo.moveSpeed += 1f;
        }
    }
}
