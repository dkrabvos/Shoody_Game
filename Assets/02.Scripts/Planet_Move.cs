using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Move : MonoBehaviour
{
    public int speed = 1; //¼Óµµ
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
