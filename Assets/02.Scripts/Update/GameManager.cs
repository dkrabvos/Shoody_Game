using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ex = 0;                // ������� ���� ����ġ
    public float exToLevelUp = 100;    //������ �ϴµ� �ʿ��� ����ġ

    public int currentLevel = 1; //���� ����
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
        ex -= exToLevelUp;
        currentLevel++;

        exToLevelUp *= 1.3f;
    }
}
