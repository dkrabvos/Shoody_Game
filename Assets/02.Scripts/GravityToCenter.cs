using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToCenter : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyDistance = 0.3f;

    void Update()
    {
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

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
                hp.TakeDamage(5); // ✅ 여기서 데미지 5로 설정
            }
        }
    }
}
