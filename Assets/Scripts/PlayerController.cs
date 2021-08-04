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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);

        if (health == 0) {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
            score = 0;
            health = 5;
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
            Destroy(other.gameObject);
        }
        else if (other.tag == "Trap") {
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.tag == "Goal") {
            Debug.Log("You win!");
        }

        
    }
}
