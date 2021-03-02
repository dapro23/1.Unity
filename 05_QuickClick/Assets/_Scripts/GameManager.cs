using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum GameSate
    {
        Loading,
        inGame,
        gameOver
    }

    public GameSate gameSate;
    
    [SerializeField]private Button restartButton;
    [SerializeField]private TextMeshProUGUI gameOverText;
    [SerializeField]private List<GameObject> targets;
    [SerializeField]private List<GameObject> death;
    [SerializeField]private TextMeshProUGUI scoreText;
   

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject panel;
    [SerializeField] private List<GameObject> lives;
    
    private int vidas;

    private int spawnRange;
    
    private int _score;

    private int score
    {
        set
        {
            _score = Mathf.Max(value, 0);
        }
        get
        {
            return _score;
        }
    }

    private void Start()
    {
        gameSate = GameSate.Loading;
        UpdateScore(1);
        score = 1;
        
        restartButton.onClick.AddListener(RestartGame2);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        scoreText.GameObject().SetActive(true);
        
    }

    public void StartGame(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                spawnRange = 3;
                vidas = 3;
                break;
            case 2:
                spawnRange = 2;
                vidas = 2;
                lives[2].SetActive(false);
                break;
            case 3:
                spawnRange = 1;
                vidas = 1;
                lives[1].SetActive(false);
                lives[2].SetActive(false);
                break;
            default:
                break;
                
        }
        
        gameSate = GameSate.inGame;
        
        UpdateScore(22);
        
        title.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        scoreText.GameObject().SetActive(true);
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnDeath());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(targets[Random.Range(0,targets.Count)]);
            gameSate = GameSate.inGame;
        }
    }
    IEnumerator SpawnDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRange);
            Instantiate(death[Random.Range(0,death.Count)]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (gameSate == GameSate.gameOver)
        {
            scoreText.text = "Max Score: " + PlayerPrefs.GetInt("MAX_SCORE", 0);
        }
        else if (gameSate == GameSate.Loading)
        {
            scoreText.text = "Max Score: " + PlayerPrefs.GetInt("MAX_SCORE", 0);
        }
        else
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
            
            if (score <= 0)
            {
                GameOver(true);
            }
        }
    }

    void GameOver(bool over)
    {
        vidas--;
        if (vidas>=0)
        {
            Image heartImage = lives[vidas].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        if (vidas <= 0)
        {
            gameSate = GameSate.gameOver;
            UpdateScore(1);
            gameOverText.GameObject().SetActive(true);
            restartButton.GameObject().SetActive(true);
            lives[0].SetActive(true);
            lives[1].SetActive(true);
            lives[2].SetActive(true);
            Debug.Log("Game Over");
        }
        else
        {
            UpdateScore(10);
        }
        
        
    }

    public void RestartGame2()
    {
        gameSate = GameSate.inGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
