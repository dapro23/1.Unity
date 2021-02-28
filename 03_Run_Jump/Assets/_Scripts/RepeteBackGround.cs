using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class RepeteBackGround : MonoBehaviour
{

    private Vector3 StartPos;
    private float repeatWidth;
    
    void Start()
    {
        StartPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartPos.x - transform.position.x > repeatWidth)
        {
            transform.position = StartPos;
        }
        
    }
}
