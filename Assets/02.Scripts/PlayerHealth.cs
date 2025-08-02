using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    public Slider healthSlider; // 👉 슬라이더 연결용

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
            // 게임 오버 처리 가능
        }
    }
}

