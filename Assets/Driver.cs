using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 350f;
    [SerializeField] float moveSpeed = 20f; 
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f; 
    // bool hasCollided = false;
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other){
        // hasCollided = true;
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost"){
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, 0.25f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0,moveAmount, 0);
    }
}
