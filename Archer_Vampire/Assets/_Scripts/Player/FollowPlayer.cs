using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField]private Vector3 offset = new Vector3(0, 4, -3);
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        this.transform.rotation = player.transform.rotation;
        
    }
}
