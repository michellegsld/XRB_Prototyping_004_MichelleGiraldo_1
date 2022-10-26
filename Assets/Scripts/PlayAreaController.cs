using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayAreaController : MonoBehaviour
{
     private int _gameDifficulty = 0;
     private float _gameTime = 60.0f;
     private float _gameTimer = 0.0f;

    [SerializeField]
    private TextMeshPro _livesTMP;
    [SerializeField]
    private TextMeshPro _timerTMP;
    
    public TextMeshPro descriptionTMP;
    public GameObject templateWall;
    
    public List<GameObject> walls;
    public GameObject currentWall;
    
    public bool gameRun = false;
    public bool playerPresent = false;
    public bool wallMoving = false;

    public int lives = 3;
    public float speed = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 0 && gameRun)
        {
            if (playerPresent)
            {
                _livesTMP.SetText("Lives: " + lives);

                _gameTimer += Time.deltaTime;
                _timerTMP.SetText("Time Left: " + (_gameTime - _gameTimer).ToString("F"));
                
                if (!wallMoving)
                {
                    Debug.Log("A new wall was sent");

                    descriptionTMP.SetText("Dodge!");

                    currentWall = Instantiate(walls[Random.Range(0, walls.Count)]);
                    currentWall.SetActive(true);

                    wallMoving = true;
                }

            }
        }
        else if (lives == 0)
        {
            _livesTMP.SetText("No Lives!");
            descriptionTMP.SetText("Good try :)");
        }
        
        if (_gameTimer >= _gameTime)
        {
            gameRun = false;
            descriptionTMP.SetText("You Win!");
            _timerTMP.SetText("Time Left: 0.00");
        }
    }

    private void ResetText()
    {
        _livesTMP.SetText("Lives: " + lives);
        descriptionTMP.SetText("Let's Play!");
        _timerTMP.SetText("Time Left: " + _gameTime.ToString("F"));
    }
    
    public void GameRestart()
    {
        _gameTimer = 0.0f;

        if (_gameDifficulty == -1) {
            EasyGame();
        } else if (_gameDifficulty == 0) {
            MediumGame();
        } else {
            HardGame();
        }
        
        gameRun = true;
    }
    
    public void EasyGame()
    {
        _gameDifficulty = -1;
        
        lives = 5;
        _gameTime = 45.0f;
        speed = 5f;
        
        ResetText();
    }
    
    public void MediumGame()
    {
        _gameDifficulty = 0;
        
        lives = 3;
        _gameTime = 60.0f;
        speed = 8f;
        
        ResetText();
    }

    public void HardGame()
    {
        _gameDifficulty = 1;
        
        lives = 2;
        _gameTime = 90.0f;
        speed = 10f;
        
        ResetText();
    }
}
