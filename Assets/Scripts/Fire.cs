using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet.GetComponent("bullet");
        bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            
            Console.WriteLine(bullet.GetComponent("bullet"));
            bullet.SetActive(true);
        }
    }
}
