using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm_Planet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GravityToCenter meteor = other.GetComponent<GravityToCenter>();
        if (meteor != null)
        {
            Debug.Log("운석 감지됨: 얼림");
            meteor.moveSpeed -= 1f;
        }
    }
}
