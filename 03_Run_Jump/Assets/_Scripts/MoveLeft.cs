using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private PlayerController _playerController;


    private void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);

        }

        if (!_playerController.GameOver)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
        
    }
}
