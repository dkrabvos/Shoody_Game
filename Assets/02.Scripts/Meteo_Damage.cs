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
    public bool isGiant = false;  // ✅ 거대 운석 여부
    public ParticleSystem destroyEffect;  // ✅ 파괴 이펙트

    void Start()
{
    if (isGiant)
    {
        hp = 50f;
        Debug.Log($"💪 거대 운석 생성됨 / 체력: {hp}");
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

        if (isGiant) Debug.Log("현재 체력: " + hp);
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
        Destroy(gameObject); // �ʿ信 ���� ����Ʈ�� �ִϸ��̼� �߰� ����
=======
{
    Debug.Log($"{gameObject.name} destroyed!");

    if (destroyEffect != null)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }

    if (isGiant)
    {

        // 💥 카메라 흔들기
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
