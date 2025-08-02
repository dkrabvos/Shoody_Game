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
            Debug.Log("운석 감지됨: 얼림");
            meteor.Freeze(freezeDuration);
        }
    }
}

