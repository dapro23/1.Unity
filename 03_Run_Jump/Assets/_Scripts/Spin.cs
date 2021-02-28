using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float rotateSpeed = 60;
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
    }
    
    void Update()
    {
        
        if (!_playerController.GameOver)
        {
            //transform.Translate(Vector3.left * (speed * Time.deltaTime));
        
            transform.localPosition += Vector3.left * (speed * Time.deltaTime);
        
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        }
        
    }
}
