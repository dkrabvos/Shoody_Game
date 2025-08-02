using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ex = 0;                // 현재까지 얻은 경험치
    public float exToLevelUp = 100;    //레벨업 하는데 필요한 경험치

    public int currentLevel = 1; //현재 레벨
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
