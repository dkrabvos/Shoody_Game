using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlanet : MonoBehaviour
{
    public float damageAmount = 25f;
    public ParticleSystem electricEffectPrefab;
    public float cooldown = 1.5f;
    private float nextDamageTime = 0f;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time < nextDamageTime)
            return;

        Meteo_Damage target = other.GetComponent<Meteo_Damage>();
        if (target != null)
        {
            target.TakeDirectDamage(damageAmount);
            PlayParticleEffect(electricEffectPrefab, other.transform.position, other.transform);
            nextDamageTime = Time.time + cooldown;
        }
    }

    void PlayParticleEffect(ParticleSystem prefab, Vector3 position, Transform parent = null, float destroyDelay = 1.5f)
    {
        Debug.Log("PlayParticleEffect 실행");
        if (prefab == null) return;

        ParticleSystem fx = Instantiate(prefab, position, Quaternion.identity);

        if (parent != null)
            fx.transform.SetParent(parent);
        if (fx != null)
        {
        Debug.Log("파티클 위치" + fx.transform.position);
        fx.Play();    
        }
        
        Destroy(fx.gameObject, destroyDelay);
    }
}
