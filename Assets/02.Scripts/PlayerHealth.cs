using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public float currentHP;
    public Slider healthSlider;

    public float maxHealth = 100f;
    public float currentHealth;


    void Start()
    {
        currentHP = maxHP;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHP;
            healthSlider.value = currentHP;
        }

        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Max(currentHP, 0);

        Debug.Log("플레이어 체력: " + currentHP);

        if (healthSlider != null)
        {
            healthSlider.value = currentHP;
        }

        if (currentHP <= 0)
        {
            Debug.Log("플레이어 사망!");
        }
    }
    public void Heal(float amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHealth);
        Debug.Log("추가된 체력 : " + amount);
        Debug.Log("현재 체력: " + currentHP);
    }

}
