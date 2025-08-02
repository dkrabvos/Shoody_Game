using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo_Damage : MonoBehaviour
{
    [Header("Meteorite Settings")]
    public float hp = 100f; // �ܺο��� ���� ����

    [Header("Damage Settings")]
    public float damagePerSecond = 10f;

    public bool isInSunLight = false;
    private float damageTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        Debug.Log($"{gameObject.name} took {amount} damage. HP: {hp}");

        if (hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} destroyed!");
        Destroy(gameObject); // �ʿ信 ���� ����Ʈ�� �ִϸ��̼� �߰� ����

        Gauge gm = FindObjectOfType<Gauge>();
        if (gm != null)
        {
            gm.AddGauge();
        }

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
            damageTimer = 0f; // Ÿ�̸� �ʱ�ȭ
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
