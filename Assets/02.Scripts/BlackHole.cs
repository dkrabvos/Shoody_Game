using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private void OnTrigger2D(Collider2D other)
    {
        GravityToCenter meteor = other.GetComponent<GravityToCenter>();
        if (meteor != null)
        {
            Debug.Log("운석 감지됨: 얼림");
            meteor.direction = ((Vector2)this.transform.position - (Vector2)other.transform.position).normalized;
        }
    }
}
