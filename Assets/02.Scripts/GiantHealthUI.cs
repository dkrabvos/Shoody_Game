using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHealthNotifier : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;

    private bool[] thresholdsTriggered = new bool[5]; // 100, 75, 50, 25, 0

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        float percent = currentHP / maxHP * 100f;

        if (!thresholdsTriggered[0] && percent <= 100) { Debug.Log("🟢 체력 100% 이하"); thresholdsTriggered[0] = true; }
        if (!thresholdsTriggered[1] && percent <= 75)  { Debug.Log("🟡 체력 75% 이하"); thresholdsTriggered[1] = true; }
        if (!thresholdsTriggered[2] && percent <= 50)  { Debug.Log("🟠 체력 50% 이하"); thresholdsTriggered[2] = true; }
        if (!thresholdsTriggered[3] && percent <= 25)  { Debug.Log("🔴 체력 25% 이하"); thresholdsTriggered[3] = true; }
        if (!thresholdsTriggered[4] && percent <= 0)   { Debug.Log("💀 체력 0% (파괴됨)"); thresholdsTriggered[4] = true; }

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
