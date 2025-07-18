using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    public GameObject winTextObject;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyCompoment;
    private int superJumpsRemaining;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        
        winTextObject.SetActive(false);
        rigidbodyCompoment = GetComponent<Rigidbody>();

        

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }
    //FixedUpdate is called once every physic update
    private void FixedUpdate() {

        rigidbodyCompoment.linearVelocity = new Vector3(horizontalInput, rigidbodyCompoment.linearVelocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) {

            return;
        }


        if (jumpKeyWasPressed) {
            float jumpPower = 5f;
            if (superJumpsRemaining > 0) {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyCompoment.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 6) {

            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
        
        if (other.gameObject.layer == 7) 
        {
           winTextObject.SetActive(true);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 8) 
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
        
    
    }

   
    }



