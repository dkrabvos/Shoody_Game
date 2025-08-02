using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo_Damage : MonoBehaviour
{
    [Header("Meteorite Settings")]
    public float hp = 10f;

    [Header("Damage Settings")]
    public float damagePerSecond = 10f;

    public bool isInSunLight = false;

<<<<<<< Updated upstream
    private float damageTimer = 0f;

    [Header("Special Settings")]
    public bool isGiant = false;  //  嫄곕 댁 щ
    public ParticleSystem destroyEffect;  //  愿 댄
=======
    public float damageTimer = 0f;
    public Boolean died = false;

    [Header("Special Settings")]
    public bool isGiant = false;  
    public GameObject destroyEffect;

    GameManager manager;
>>>>>>> Stashed changes

    void Start()
{
    if (isGiant)
    {
        hp = 50f;
        Debug.Log($" 嫄곕 댁 깅 / 泥대: {hp}");
    }
}

    void Update()
    {
        if (isInSunLight)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= 1f)
            {
                TakeDamage(damagePerSecond);
                damageTimer = 0f;
            }
        }
    }

    private void TakeDamage(float amount)
    {
        hp -= amount;
<<<<<<< Updated upstream

        if (isGiant) Debug.Log(" 泥대: " + hp);
        if (hp <= 0f)
        {
            Die();
        }
    }

    public void TakeDirectDamage(float amount)
    {
        hp -= amount;
        
        if (hp <= 0f)
        {
=======
        if (hp <= 0f)
        {
            died = true;
>>>>>>> Stashed changes
            Die();
        }
    }

    private void Die()

{
    Debug.Log($"{gameObject.name} destroyed!");

    if (destroyEffect != null)
    {
<<<<<<< Updated upstream
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
=======
        if (died)
        {
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }

            if (isGiant)
            {
                if (CameraShake.Instance != null)
                    StartCoroutine(CameraShake.Instance.Shake(0.5f, 0.4f));
            }
            manager.ex += 10;

            Destroy(gameObject);
            died = false;
        }
>>>>>>> Stashed changes
    }

    if (isGiant)
    {

        //  移대 ㅺ린
        if (CameraShake.Instance != null)
            StartCoroutine(CameraShake.Instance.Shake(0.5f, 0.4f));
    
        
    }
    else
    {

        Gauge gm = FindObjectOfType<Gauge>();
        if (gm != null)
        {
            gm.AddGauge();
        }


    }

    Destroy(gameObject);
}

void ResetTimeScale()
{
    Time.timeScale = 1f;
}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SunLight"))
        {
            isInSunLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SunLight"))
        {
            isInSunLight = false;
            damageTimer = 0f;
        }
    }

    public void TakeDirectDamage(float amount)
    {
        hp -= amount;
        Debug.Log($"{gameObject.name} cursed! HP: {hp}");

        if (hp <= 0f)
        {
            Die();
        }
    }

   
}
