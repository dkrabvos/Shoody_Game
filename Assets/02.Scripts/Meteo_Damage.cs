using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo_Damage : MonoBehaviour
{
    [Header("Meteorite Settings")]
    public float hp = 10f;

    [Header("Damage Settings")]
    public float damagePerSecond = 10f;
<<<<<<< Updated upstream

    private bool isInSunLight = false;
=======
    public bool isInSunLight = false;
>>>>>>> Stashed changes
    private float damageTimer = 0f;

    [Header("Special Settings")]
    public bool isGiant = false;  // âœ… ê±°ëŒ€ ìš´ì„ ì—¬ë¶€
    public ParticleSystem destroyEffect;  // âœ… íŒŒê´´ ì´íŽ™íŠ¸

    void Start()
{
    if (isGiant)
    {
        hp = 50f;
        Debug.Log($"ðŸ’ª ê±°ëŒ€ ìš´ì„ ìƒì„±ë¨ / ì²´ë ¥: {hp}");
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

        if (isGiant) Debug.Log("í˜„ìž¬ ì²´ë ¥: " + hp);
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
            Die();
        }
    }

    private void Die()
<<<<<<< Updated upstream
    {
        Debug.Log($"{gameObject.name} destroyed!");
        Destroy(gameObject); // ÇÊ¿ä¿¡ µû¶ó ÀÌÆåÆ®³ª ¾Ö´Ï¸ÞÀÌ¼Ç Ãß°¡ °¡´É
=======
{
    Debug.Log($"{gameObject.name} destroyed!");

    if (destroyEffect != null)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }

    if (isGiant)
    {

        // ðŸ’¥ ì¹´ë©”ë¼ í”ë“¤ê¸°
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
>>>>>>> Stashed changes
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
}
