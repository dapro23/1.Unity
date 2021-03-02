using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireController : MonoBehaviour
{
    //[SerializeField] private bool hit = false;
    private Animator _animator;
    private GameObject player;
    private Vector3 direction;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        direction = (player.transform.position - this.transform.position).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            _animator.SetBool("Die", true);
            
            //Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        
        
    }

    private void FixedUpdate()
    {
        transform.LookAt(player.transform);
    }
}
