using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlanet : MonoBehaviour
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
            GravityToCenter meteor = collision.GetComponent<GravityToCenter>();
            meteor.isInBlackhole = true;
            sound.Play();
            meteor.final = this.transform.position;
            Debug.Log("ºí·¢È¦ ¾È¿¡ µé¾î¿È");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteo"))
        {
            GravityToCenter meteor = collision.GetComponent<GravityToCenter>();
            meteor.isInBlackhole = false;
            Debug.Log("ºí·¢È¦ ¾È¿¡¼­ ³ª°¨");
        }
    }
}
