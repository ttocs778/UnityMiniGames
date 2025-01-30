using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI helathText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    private Rigidbody rb;
    private float MovementX;
    private float MovementY;
    private int count;
    private int healthcount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        healthcount = 3;
        SetText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        MovementX = movementVector.x;
        MovementY = movementVector.y;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(MovementX, 0.0f, MovementY);

        rb.AddForce(movement * speed, ForceMode.VelocityChange);  
    }
    void OnTriggerEnter(Collider other) 
    {   
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            healthcount -= 1;
            SetText();
        }
    }


    void SetText() 
    {
        countText.text =  "Count: " + count.ToString();
        helathText.text =  "Health: " + healthcount.ToString();
        if (healthcount == 0)
        {   
            loseTextObject.SetActive(true);
        }else if(count>=7){
            winTextObject.SetActive(true);
        }

        }
    }
