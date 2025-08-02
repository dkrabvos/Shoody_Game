using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StromPlanet : MonoBehaviour
{
    private void OnTrigger2D(Collider2D other)
    {
        GravityToCenter meteor = other.GetComponent<GravityToCenter>();
        if (meteor != null)
        {
            meteor.moveSpeed -= 1f;
        }
    }
}
