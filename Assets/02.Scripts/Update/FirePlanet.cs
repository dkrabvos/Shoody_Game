using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlanet : MonoBehaviour
{
    public int damage = 5;
    public float tickInterval = 0.5f;
    public int range = 7;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteo"))
        {
            Meteo_Damage meteorite = collision.GetComponent<Meteo_Damage>();
            Fire(range, meteorite);
        }
    }

    void Fire(int range, Meteo_Damage meteo)
    {
        for (int i = 0; i < range; i++)
        {
            StartCoroutine(FireCoroutine(tickInterval, meteo, damage));
        }
    }

    private IEnumerator FireCoroutine(float tick, Meteo_Damage meteo, int damage)
    {
        sound.Play();
        meteo.TakeDamage(damage);
        yield return new WaitForSeconds(tick);
    }
}
