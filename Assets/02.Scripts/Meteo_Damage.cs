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

    public float damageTimer = 0f;

    [Header("Special Settings")]
    public bool isGiant = false;  
    public ParticleSystem destroyEffect;

    GameManager manager;

    void Start()
    {
        if (isGiant) hp = 50f;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0f) Die();
    }

    private void Die()
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
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
}
