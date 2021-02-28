using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private GameObject[] enemies;
    [SerializeField] private int animalIndex;
    
    private float spawnPosZ;
    private int spawnRangex = 14;

    [SerializeField, Range(0.1f, 4.0f)]private float startDelay = 2f;
    [SerializeField, Range(0.1f, 4.0f)]private float spawnInterval = 1f;
    
    private void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

   
    private void SpawnRandomObject()
    {
        animalIndex = Random.Range(0, enemies.Length -1);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangex, spawnRangex), 0, spawnPosZ);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
        
    }



}
