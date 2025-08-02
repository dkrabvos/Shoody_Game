using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlanet : MonoBehaviour
{
    public float damageAmount = 25f;

    public GameObject electricEffectPrefab;

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
            target.TakeDamage(damageAmount);
            PlayParticleEffect(electricEffectPrefab, other.transform.position, other.transform);
            nextDamageTime = Time.time + cooldown;
        }
    }


    void PlayParticleEffect(GameObject prefab, Vector3 position, Transform parent = null, float destroyDelay = 1.5f)

    {
        Debug.Log("PlayParticleEffect 실행");
        if (prefab == null) return;


        GameObject fx = Instantiate(prefab, position, Quaternion.identity);

        if (parent != null)
            fx.transform.SetParent(parent);

        
        Destroy(fx.gameObject, destroyDelay);
    }

    //스플래쉬 데미지는 이후 Meteo_Damage에서 수정할 예정

}
