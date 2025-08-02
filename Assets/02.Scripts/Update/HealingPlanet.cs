using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlanet : MonoBehaviour
{
    public float healAmount = 10f;      // ȸ����
    public float healInterval = 2f;     // ȸ�� �ֱ� (�⺻ 2��)
    public PlayerHealth sunLight;     // �¾� ������Ʈ ����

    private float timer = 0f;

    void Update()
    {
        if (sunLight == null) return;

        timer += Time.deltaTime;
        if (timer >= healInterval)
        {
            sunLight.Heal(healAmount);
            timer = 0f;
        }
    }
}
