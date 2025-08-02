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
            Debug.Log("� ������: ��");
            meteor.moveSpeed -= 1f;
        }
    }
}
