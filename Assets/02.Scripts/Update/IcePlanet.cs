using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlanet : MonoBehaviour
{
    public float freezeDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GravityToCenter meteor = other.GetComponent<GravityToCenter>();
        if (meteor != null)
        {
            Freeze(freezeDuration,meteor);
        }
    }

    public void Freeze(float duration, GravityToCenter meteo)
    {
        StartCoroutine(FreezeCoroutine(meteo, duration));
    }

    private IEnumerator FreezeCoroutine(GravityToCenter meteo, float duration)
    {
        float prevSpeed = meteo.moveSpeed;
        meteo.moveSpeed = 0f;

        // 파란색으로 변경
        if (meteo.spriteRenderer != null)
            meteo.spriteRenderer.color = Color.cyan;

        // 파티클 효과
        /*if (meteo.freezeEffectPrefab != null)
        {
            ParticleSystem fx = Instantiate(meteo.freezeEffectPrefab, transform.position, Quaternion.identity);
            fx.transform.SetParent(transform);
            Destroy(fx.gameObject, 2f);
        }
        */
        yield return new WaitForSeconds(duration);

        // 원래 상태로 복원
        meteo.moveSpeed = prevSpeed;
        if (meteo.spriteRenderer != null)
            meteo.spriteRenderer.color = meteo.originalColor;
    }
}

