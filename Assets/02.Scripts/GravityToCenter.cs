using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToCenter : MonoBehaviour
{
    public BlackholePlanet blackholePlanet;

    public float moveSpeed = 2f;
    public float destroyDistance = 0.3f;

<<<<<<< Updated upstream
    void Update()
    {
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Vector2.zero) < destroyDistance)
=======

    [HideInInspector] public bool isFreezable = true;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public ParticleSystem freezeEffectPrefab; // 얼릴 때 이펙트



    void Start()
    {
        // 스프라이트 색상 저장
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
        blackholePlanet = GetComponent<BlackholePlanet>();
    }

    void Update()
    {
        if (blackholePlanet.isInBlackhole)
>>>>>>> Stashed changes
        {
            blackholePlanet.PullMeteorites();
        }
        else
        {
            // 방향 계산
            Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;

            // 이동
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

            // 중앙에 도달하면 파괴 및 데미지
            if (Vector2.Distance(transform.position, Vector2.zero) < destroyDistance)
            {
                DamagePlayer();
                Destroy(gameObject);
            }
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
                hp.TakeDamage(5); // ✅ 여기서 데미지 5로 설정
            }
        }
    }
}
