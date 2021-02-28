using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private float horizontalInput;
    private float verticalInput;
    [SerializeField]private float jumpInput;

    

    [SerializeField]private bool jumpKeyWasPressed;
    private bool isOnTheGround = true;
    
    [SerializeField]private float gravityMultiplier = 1;
    [SerializeField]private float jumpForce = 1;
    [SerializeField]private float speed = 8;
    [SerializeField] private float time;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxis("Jump");

        time = Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space)&&isOnTheGround)
        {
            jumpKeyWasPressed = true;
        }


        if (Math.Abs(transform.position.x)>=23||Math.Abs(transform.position.z)>=23)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24)
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -24)
            {
                transform.position = new Vector3(-24, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            }
            if (transform.position.x < -24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24);
            }
        }

    }
    
    private void FixedUpdate()
    {
        if (jumpKeyWasPressed)
        {
            jumpKeyWasPressed = false;
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * (jumpForce * jumpInput), ForceMode.Impulse);
        }

        //_rigidbody.velocity = new Vector3(horizontalInput * speed, _rigidbody.velocity.y, verticalInput * speed);
        
        _rigidbody.AddForce(Vector3.forward * (verticalInput * speed), ForceMode.Force);
        _rigidbody.AddForce(Vector3.left * (horizontalInput * speed), ForceMode.Force);
        
        //_rigidbody.AddForce(Vector3.left * (Time.deltaTime * horizontalInput * speed));
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
    
}
