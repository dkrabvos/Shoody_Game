using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToCenter_Giant : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float destroyDistance = 0.3f;
    public float shakeFrequency = 3f;

    private float shakeTimer;

    void Start()
    {
        shakeTimer = Random.Range(0f, 100f);
    }

    void Update()
    {
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;



        // 이동 적용
        transform.position += movement ;

        // 중앙 도달하면 파괴
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
                hp.TakeDamage(20); // 큰 피해
            }
        }
    }
}
