using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // solo expone la variable al Inspector
    [SerializeField]private Transform groudCheckTransform = null;
    
    [SerializeField]private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponet;
    


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) 
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");


    }

    //se actualiza 100 veces por segundo
    private void FixedUpdate()
    {

        rigidbodyComponet.velocity = new Vector3(horizontalInput, rigidbodyComponet.velocity.y, 0);

        /*if (Physics.OverlapSphere(groudCheckTransform.position, 0.1f, playerMask).Length == 0) 
        {
            return;
        }
       */


        if (jumpKeyWasPressed)
        {
            rigidbodyComponet.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        
    }

    /*
     
    private bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }*/

}
