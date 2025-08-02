using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StromPlanet : MonoBehaviour
{
    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteo"))
        {
            sound.Play();
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
