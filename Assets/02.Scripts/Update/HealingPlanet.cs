using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlanet : MonoBehaviour
{
    public float healAmount = 10f;      // 회복량
    public float healInterval = 2f;     // 회복 주기 (기본 2초)
    public PlayerHealth sunLight;     // 태양 오브젝트 참조

    private float timer = 0f;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();    
    }

    void Update()
    {
        if (sunLight == null) return;

        timer += Time.deltaTime;
        if (timer >= healInterval)
        {
            sunLight.Heal(healAmount);
            sound.Play();
            timer = 0f;
        }
    }
}
