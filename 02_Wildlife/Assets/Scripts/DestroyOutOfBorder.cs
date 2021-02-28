using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyOutOfBorder : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -15f;
    private float sideBound = 23f;
    
    void Update()
    {
        if (transform.position.z > topBound ||
            transform.position.x > sideBound ||
            transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
            Time.timeScale = 0;

        }

    }
}
