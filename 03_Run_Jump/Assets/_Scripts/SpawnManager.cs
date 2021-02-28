using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField]private GameObject[] objects;
    [SerializeField] private int objectsIndex;
    
   
    [SerializeField, Range(0.1f, 4.0f)]private float startDelay = 2f;
    //[SerializeField, Range(0.1f, 4.0f)]private float spawnInterval = 1f;
    
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
        
        InvokeRepeating(nameof(SpawnRandomObject), startDelay, Random.Range(1.0f, 3));
    }

   
    private void SpawnRandomObject()
    {
        if (!_playerController.GameOver)
        {
            objectsIndex = Random.Range(0, objects.Length - 1);
            Vector3 spawnPos = transform.position;
            Instantiate(objects[objectsIndex], spawnPos, objects[objectsIndex].transform.rotation);
        }
    }
}
