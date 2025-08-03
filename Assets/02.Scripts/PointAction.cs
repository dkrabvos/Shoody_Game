using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointAction : MonoBehaviour
{
    public PlanetSkill PlanetSkill;

    Vector2 localscale;
    private void Start()
    {
        localscale = this.transform.localScale;
    }


    public void OnPointEnter()
    {
        this.GetComponent<Transform>().localScale *= 1.2f;
    }

    public void OnPointerExit()
    {
        this.GetComponent<Transform>().localScale = localscale;
    }

    public void Clicked()
    {
        Debug.Log(this.gameObject);
        PlanetSkill.SetSkill(this.gameObject);
    }
}
