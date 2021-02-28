using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamara : MonoBehaviour
{

    public float rotationSpeed = 4;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * (horizontalInput * rotationSpeed * Time.deltaTime));

    }
}
