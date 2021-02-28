using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
   
    void Start()
    {
        float force = Random.Range(12, 16);
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.up*force, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10));
        transform.position = new Vector3(Random.Range(-4.5f,4.5f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.y<0)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnMouseEnter()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
