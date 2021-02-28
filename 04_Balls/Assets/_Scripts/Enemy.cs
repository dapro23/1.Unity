using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float moveForce;

    private Rigidbody _rigidbody;
    private GameObject player;
    private Vector3 direction;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        
    }

    
    void Update()
    {
        direction = (player.transform.position - this.transform.position).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(direction*moveForce, ForceMode.Force);
    }
}
