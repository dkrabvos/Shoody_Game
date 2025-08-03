using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointAction : MonoBehaviour
{
    public PlanetSkill PlanetSkill;
    public GameObject skillUI;
    public UIManager uiManager;

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
        uiManager.UItoSkill(this.gameObject);
        skillUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
