using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    
    [SerializeField,Range(1,3)]private int difficulty;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(difficulty);
        
    }
}
