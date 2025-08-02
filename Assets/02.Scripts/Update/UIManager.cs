using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentEx;
    public TextMeshProUGUI currentLevel;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        UpdateUI();    
    }

    void UpdateUI()
    {
        if (currentEx != null)
            currentEx.text = "Ex: " + gameManager.ex;

        if (currentLevel != null)
            currentLevel.text = "Level: " + gameManager.currentLevel;
    }
}
