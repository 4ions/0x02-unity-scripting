using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public Vector3 inputVector;

    private int score = 0;

    public int health = 5;

    Rigidbody rb;

    private bool _canMove = true;

    // UI
    private UiManager ui;

    [SerializeField]
    private CameraController cc;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ui = FindObjectOfType<UiManager>();

        cc = FindObjectOfType<CameraController>();

        
    }

    void Update(){

        if (_canMove)
        {
            inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }

        if (health == 0) {
            _canMove = false;
            Debug.Log("Game Over!");
            ui.Message("Game Over!");
            score = 0;
            health = 5;
            Invoke("ResetLevel", 2);
        }


        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.tag == "Ground")
            {
                //isGrounded = true;
            }


        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            //isGrounded = false;
        }

    }

    void FixedUpdate()
    {
        rb.AddForce(inputVector);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickup"){
            score++;
            Debug.Log("Score: " + score);
            ui.AddCoins(score);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Trap") {
            health--;
            ui.HealthCount(health);
            Debug.Log("Health: " + health);
            cc._shaked = true;
        }
        else if (other.tag == "Goal") {
            Debug.Log("You win!");
            ui.Message("You Win!");
        }

        
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(0);
        _canMove = true;
    }

    
}
