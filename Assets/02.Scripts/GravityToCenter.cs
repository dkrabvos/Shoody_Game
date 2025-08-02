using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToCenter : MonoBehaviour
{
    public float moveSpeed = 2f;          // 일정한 이동 속도
    public float destroyDistance = 0.3f;  // 중앙 도달 거리

    void Update()
    {
        // 중앙 방향으로 일정 속도 이동
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        // 중앙 도달 시
        if (Vector2.Distance(transform.position, Vector2.zero) < destroyDistance)
        {
            DamagePlayer();
            Destroy(gameObject); // 운석 제거
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
                hp.TakeDamage(1); // 체력 1 감소
            }
        }
    }
}
