using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed_Planet : MonoBehaviour
{
    public float damage = 20f;
    public float tickInterval = 0.5f;
    public float damageRange = 5f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickInterval)
        {
            ApplyDamageToNearbyMeteorites();
            timer = 0f;
        }
    }

    void ApplyDamageToNearbyMeteorites()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, damageRange);
        foreach (Collider2D col in hits)
        {
            Meteo_Damage meteorite = col.GetComponent<Meteo_Damage>();
            if (meteorite != null)
            {
                meteorite.TakeDirectDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 에디터에서 범위 확인용
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRange);
    }

}
