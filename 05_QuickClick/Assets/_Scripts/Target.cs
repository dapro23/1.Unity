using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private GameManager _gameManager;

    [SerializeField] private ParticleSystem explosion;
   
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
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
        if (this.CompareTag("Death"))
        {
            _gameManager.UpdateScore(-15);
        }
        else
        {
            _gameManager.UpdateScore(5);
        }
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            if (this.CompareTag("Death"))
            {
                Destroy(gameObject);
                _gameManager.UpdateScore(-10);
            }
            else
            {
                Destroy(gameObject);
                _gameManager.UpdateScore(-5);
            }
        }
    }
}
