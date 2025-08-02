using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToCenter : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyDistance = 0.3f;

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
    }

    void Update()
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
    }

    // ❄️ 얼리기 기능
    public void Freeze(float duration)
    {
        StartCoroutine(FreezeCoroutine(duration));
    }

    private IEnumerator FreezeCoroutine(float duration)
    {
        float prevSpeed = moveSpeed;
        moveSpeed = 0f;

        // 파란색으로 변경
        if (spriteRenderer != null)
            spriteRenderer.color = Color.cyan;

        // 파티클 효과
        if (freezeEffectPrefab != null)
        {
            ParticleSystem fx = Instantiate(freezeEffectPrefab, transform.position, Quaternion.identity);
            fx.transform.SetParent(transform);
            Destroy(fx.gameObject, 2f);
        }

        yield return new WaitForSeconds(duration);

        // 원래 상태로 복원
        moveSpeed = prevSpeed;
        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }
}
