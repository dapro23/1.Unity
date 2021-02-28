using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    [SerializeField, Range(1,40)]private int jumpForce = 300;
    [SerializeField, Range(0.2f,4f)] private float gravityMultiplier = 1;
    private bool _isOnTheGround = true;
    
    [FormerlySerializedAs("_gameOver")] [SerializeField]private bool gameOver = false;
    //es una forma simplificada de definir un get para otars clases
    //su privada homonima se debe llamar con minuscula y _
    public bool GameOver { get => gameOver; }

    
    private Animator _animator;
    const string SPEED_MULTIPLIER = "Speed Multiplier";
    const string JUMP_TRIGER = "Jump_trig";

    public ParticleSystem explosion;
    public ParticleSystem runDirt;

    //Audio
    [SerializeField] private AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [SerializeField, Range(0.2f, 3)] private float audioVolume = 1;

    private float speedMultiplier = 1;
    
    
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerRb.AddForce(Vector3.up * 200);

        //Physics.gravity = Physics.gravity * gravityMultiplier;
        Physics.gravity *= gravityMultiplier;
        
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        runDirt.Play();
    }

    
    void Update()
    {
        speedMultiplier += Time.deltaTime / 10;
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);
        
        if (Input.GetKeyDown(KeyCode.Space)&&_isOnTheGround&&!gameOver)
        {
            runDirt.Stop();
            _playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            _isOnTheGround = false;
            _animator.SetTrigger(JUMP_TRIGER);
            _audioSource.PlayOneShot(jumpSound, audioVolume);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            runDirt.Play();
            _isOnTheGround = true;
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            _animator.SetBool("Death_b", true);
            explosion.Play();
            _audioSource.PlayOneShot(crashSound, audioVolume);
            Debug.Log("Game Over! ;)");
            Invoke("RestartGame", 3.0f);
        }
        
    }

    void RestartGame()
    {
        //speedMultiplier = 1;
        //SceneManager.UnloadSceneAsync("Prototype 3");
        //SceneManager.LoadScene("Prototype 3", LoadSceneMode.Single);
    }



}
