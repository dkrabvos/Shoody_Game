using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ex = 0;                // ������� ���� ����ġ
    public float exToLevelUp = 100;    //������ �ϴµ� �ʿ��� ����ġ

    public int currentLevel = 1; //���� ����

    public GameObject skillUI;

    public PlanetSkill skill;

    // Start is called before the first frame updat
    public void Update()
    {
        if (ex >= exToLevelUp)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        Time.timeScale = 0f;
        ex -= exToLevelUp;
        currentLevel++;
        skillUI.SetActive(true);
        skill.SelectSkill();
        exToLevelUp *= 1.3f;
    }
}
