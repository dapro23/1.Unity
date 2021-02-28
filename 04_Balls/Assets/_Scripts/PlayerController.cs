using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveForce;
    [SerializeField]private Vector3 vectorExample;

    private bool hasPowerUpSpeed;
    
    private GameObject focalPoint;

    private Rigidbody _rigidbody;    
    private float forwardInput;

    //corutina
    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(4);
        hasPowerUpSpeed = false;
    }
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindWithTag("Focal Point");
        hasPowerUpSpeed = false;
    }

    
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        if (hasPowerUpSpeed)
        {
            StartCoroutine(PowerUpCountdown());
        }


        vectorExample = focalPoint.transform.forward;
    }

    private void FixedUpdate()
    {
        if (hasPowerUpSpeed)
        {
            //Duplica la velocidad
            _rigidbody.AddForce(focalPoint.transform.forward * (forwardInput * moveForce * 2));
        }
        else
        {
            _rigidbody.AddForce(focalPoint.transform.forward * (forwardInput * moveForce));
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUpSpeed = true;
            Destroy(other.gameObject);
        }
    }
}
