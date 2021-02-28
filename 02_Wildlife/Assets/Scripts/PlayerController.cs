using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed = 10.0f;
    
    [SerializeField] private float xRange = 15.0f;

    [SerializeField] private GameObject projectilePrefab;
    
    
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * speed * Time.deltaTime) );

        if (transform.position.x <-xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x >xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            
            // que se quiere instanciar, donde/posicion, rotacion
            Instantiate(projectilePrefab, pos, projectilePrefab.transform.rotation);
        }


    }
    
    
    
    
    
}
