using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnManager : MonoBehaviour
{
   
    [SerializeField]private GameObject arrow;
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GameObject.FindWithTag("Player")
            .GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerController.Shoot)
        {
            SpawnRandomObject();
        }
    }


    private void SpawnRandomObject()
    {
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
