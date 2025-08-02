using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public Slider healthSlider;

    void Start()
    {
        currentHP = maxHP;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHP;
            healthSlider.value = currentHP;
        }
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
}
