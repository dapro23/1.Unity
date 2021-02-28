using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
    }

    /// <summary>
    /// Generate a position inside the game zone
    /// </summary>
    /// <returns>Return a random position</returns>
    private Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(1,10);
        float z = Random.Range(1,10);
        return new Vector3(x,transform.position.y,z);
    }
}
