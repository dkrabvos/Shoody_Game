using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteo"))
        {
            Meteo_Damage Damage = other.GetComponent<Meteo_Damage>();
            Damage.isInSunLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Meteo"))
        {
            Meteo_Damage Damage = other.GetComponent<Meteo_Damage>();
            Damage.isInSunLight = false;
            Damage.damageTimer = 0;
        }
    }
}
