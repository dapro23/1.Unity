using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireController : MonoBehaviour
{
    [SerializeField] private bool hit = false;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
    
}
