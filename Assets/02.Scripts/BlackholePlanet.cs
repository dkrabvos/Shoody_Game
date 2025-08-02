using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholePlanet : MonoBehaviour
{
    [Header("Blackhole Settings")]
    public float pullRange = 5f;           // 감지 반경
    public float pullStrength = 5f;        // 끌어당기는 힘 세기
    public float pullDelay = 0.02f;        // 끌기 주기 (짧게 할수록 자연스러움)

    private float timer = 0f;

    public bool isInBlackhole = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= pullDelay)
        {
            PullMeteorites();
            timer = 0f;
        }
    }
    public void PullMeteorites()
    {
        // 감지 범위 내의 콜라이더 가져오기
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pullRange);

        foreach (Collider2D hit in hits)
        {
            // Meteorite 태그 또는 특정 컴포넌트로 필터링
            if (hit.CompareTag("Meteo"))
            {
                isInBlackhole = true;
                Rigidbody2D rb = hit.attachedRigidbody;
                if (rb != null)
                {
                    // 블랙홀을 향한 방향 벡터
                    Vector2 directionToCenter = ((Vector2)transform.position - rb.position).normalized;

                    // 거리 기반 감속 (옵션)
                    float distance = Vector2.Distance(transform.position, rb.position);
                    float force = pullStrength * (1f - (distance / pullRange)); // 가까울수록 강하게

                    // 끌어당기기
                    rb.AddForce(directionToCenter * force, ForceMode2D.Force);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0f, 0f, 0.4f);
        Gizmos.DrawSphere(transform.position, pullRange);
    }
}
