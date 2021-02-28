using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1,40)]private int jumpForce = 5;
    [SerializeField, Range(0.2f,2f)] private float gravityMultiplier = 1;
    [SerializeField] private float speedForward;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody _playerRb;
    private Animator _animator;
    
    private bool gameOver = false;
    public bool GameOver { get => gameOver; }
    
    private bool _isOnTheGround = true;
    
    private bool jumpKeyWasPressed = false;
    private float horizontalInputMouse;
    private float verticalInput;
    
    private float jumpInput;
    [SerializeField]private bool shoot;

    public bool Shoot
    {
        get => shoot;
    }

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
        //initial jump, only for my preference
        _playerRb.AddForce(Vector3.up * 200);

        Physics.gravity *= gravityMultiplier;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&_isOnTheGround)
        {
            jumpKeyWasPressed = true;
        }
        
        //horizontalInput = Input.GetAxis("Horizontal");
        horizontalInputMouse = Input.GetAxis("Horizontal");
        //horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxis("Jump");
        
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            shoot = true;
            //shoot = Input.GetAxis("Fire1");
        }

        _animator.SetFloat("HorizontalSpeed", verticalInput);
        _animator.SetFloat("VerticalSpeed", jumpInput);
        
    }

    private void FixedUpdate()
    {
        if (jumpKeyWasPressed)
        {
            jumpKeyWasPressed = false;
            _isOnTheGround = false;
            _animator.SetBool("Grounded", false);
            _playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            //StartCoroutine(isOnTheGround());
        }

        if (shoot)
        {
            _animator.SetTrigger("Shoot");
            shoot = false;
        }

        transform.Translate(Vector3.forward*(verticalInput * speedForward));
        
        //transform.Translate(Vector3.right*(horizontalInput * speedForward));

        //_playerRb.AddForce(transform.forward* (verticalInput * speedForward));

        transform.Rotate(Vector3.up * (horizontalInputMouse * rotationSpeed));
        
        

    }

    IEnumerator isOnTheGround()
    {
        yield return new WaitForSeconds(1.5f);
        _isOnTheGround = true;
        _animator.SetBool("Grounded", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnTheGround = true;
            _animator.SetBool("Grounded", true);
        }
    }
    
}
