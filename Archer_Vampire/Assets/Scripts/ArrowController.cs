using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private GameObject player;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distancia = Vector3.Distance(player.transform.position, transform.position);

        if (distancia > 30)
        {
            Destroy(gameObject);
        }


        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
       
        
    }
}
