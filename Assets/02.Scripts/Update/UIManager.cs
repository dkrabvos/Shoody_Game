using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentEx;
    public TextMeshProUGUI currentLevel;

    public List<GameObject> selections = new List<GameObject> (6);
    public List<GameObject> AlreadySelections = new List<GameObject>(3);
    public List<GameObject> positions = new List<GameObject> (3);

    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        //UpdateUI();    
    }
    /*
    void UpdateUI()
    {
        if (currentEx != null)
            currentEx.text = "Ex: " + gameManager.ex;

        if (currentLevel != null)
            currentLevel.text = "Level: " + gameManager.currentLevel;
    }
    */
    public void Selection(int rand_index, int pos_index)
    { 
    selections[rand_index].GetComponent<RectTransform>().position = positions[pos_index].GetComponent<RectTransform>().position;
    selections[rand_index].SetActive(true); 
    }
}
