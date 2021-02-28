using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0,50), Tooltip("Velocidad lineal del coche")] 
    private float speed = 10.0f;
    
    [SerializeField, Range(0,40), Tooltip("Velocidad de giro del coche")]
    private float turnSpeed = 5f;
    
    [SerializeField]private float horizontalInput, verticalInput;
    
    // Update is called once per frame
    void Update()
    {
        //se obtiene cuanto se ha desplazado con los a y d el eje orizontal entre 0 - 1
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // S = V*T*(direccion)
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput));
        
        //desplazamiento horizontal
        transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));

        
    }

    private void FixedUpdate()
    {
        
    }
    
    
    
    
}
