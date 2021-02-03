using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    

    private Rigidbody rb;

    private int count;
    private float movementX;
    private float movementY;
    public AudioSource sound;
    
    public Vector3 startPoint = new Vector3(0, 10, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);

        
        sound = gameObject.GetComponent<AudioSource>();

        
        rb.MovePosition(startPoint);

        rb.useGravity = false;

    }

    

    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump);
            rb.useGravity = true;
                
            
               
            
        }


       
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 18)
        {
            winTextObject.SetActive(true);
           
            sound.Play();

        }
    }
   void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


        rb.AddForce(movement * speed);

       

    }

    private void OnTriggerEnter(Collider other)
    {
       


        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

       



    }



}
