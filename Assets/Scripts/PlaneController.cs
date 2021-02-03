using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    Plane plane;
   
    // Start is called before the first frame update
    void Start()
    {
        plane = gameObject.GetComponent<Plane>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("Ground"))
        {
            other.gameObject.SetActive(false);
            
        }




    }
}
