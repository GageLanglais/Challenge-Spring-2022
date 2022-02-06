using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI LifecountText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;
    private int Lifecount;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;

        SetCountText();

        Lifecount = 3;

        SetLifeCountText();



        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PIckup"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
             
        else if (other.gameObject.CompareTag("Enemy"))
        {
          other.gameObject.SetActive(false);
          Lifecount = Lifecount - 1;  
          SetLifeCountText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == 12)
        {
            // Set the text value of your 'winText'
            transform.position = new Vector3(60.0f, 0.5f, 0.0f); 
        }

        if (count >= 20)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            speed = 0;
        }
    }

    void SetLifeCountText()
    {
        LifecountText.text = "Life: " + Lifecount.ToString();

        if (Lifecount == 0)
        {
            // Set the text value of your 'winText'
            speed = 0;

            loseTextObject.SetActive(true);
            Destroy(gameObject);
        }

    }
}