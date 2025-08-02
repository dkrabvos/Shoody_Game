using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityToCenter : MonoBehaviour
{
    public BlackholePlanet blackholePlanet;

    public float moveSpeed = 2f;
    public float destroyDistance = 0.3f;

    public bool isInBlackhole = false;

    public Vector2 direction;

    public Vector2 final;

    [HideInInspector] public bool isFreezable = true;

    public SpriteRenderer spriteRenderer;
    public Color originalColor;

    void Start()
    {
        // 스프라이트 색상 저장
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
        
        final = Vector2.zero;
}


    void Update()
    {
        Move(isInBlackhole);
    }

    void Move(bool inInBlackhole)
    {
        if (isInBlackhole) direction = (final - (Vector2)transform.position).normalized;
        else direction = (Vector2.zero - (Vector2)transform.position).normalized;

        // 이동
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        // 중앙에 도달하면 파괴 및 데미지
        if (Vector2.Distance(transform.position, Vector2.zero) < destroyDistance)
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerHealth hp = player.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(5);
            }
        }
        Destroy(gameObject);
    }
}
