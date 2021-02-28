using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoloController : MonoBehaviour
{
    private Animator _animator;

    private const string MOVE_HANDS = "Move Hands";
    private bool isMovingHands = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        
        //por defecto se pone a false la variable
        _animator.SetBool(MOVE_HANDS, isMovingHands);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHands = !isMovingHands;
            _animator.SetBool(MOVE_HANDS, isMovingHands);
        }
    }
}
