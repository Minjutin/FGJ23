using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f, Spin = 1.0f, verticalInput, horizontalInput;

    void Start()
    {
        
    }
    void Update()
    {       
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.left * movementSpeed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * Spin * horizontalInput * Time.deltaTime);
    }
}
