using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private List<GameObject> death;
    
    void Start()
    {
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnDeath());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(targets[Random.Range(0,targets.Count)]);
        }
    }
    IEnumerator SpawnDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(death[Random.Range(0,death.Count)]);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
