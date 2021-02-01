using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Text countText;
    public Text winText;
    public float explosionforce = 0;
    public AudioSource audioSource;

    private Rigidbody rb;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        audioSource = gameObject.GetComponent<AudioSource>();


    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        

        rb.AddForce(movement * speed);
        rb.AddExplosionForce(40, movement, 7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            
        }
    }

    void SetCountText()
    {

        Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            

            countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {

            audioSource.Play();
            winText.text = "You Win!!!";
            rb.AddExplosionForce(1000, vector, 300);
        }
    }



}
