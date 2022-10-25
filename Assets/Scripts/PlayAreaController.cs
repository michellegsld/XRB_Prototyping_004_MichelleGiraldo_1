using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayAreaController : MonoBehaviour
{
    private TextMeshPro _livesTMP;
    private TextMeshPro _timerTMP;
    private TextMeshPro _endTMP;

    
    private float _gameTime = 60.0f;
    private float _gameTimer = 0.0f;
    
    public bool gameRun = false;

    public bool playerPresent = false;
    
    public bool wallMoving = false;

    public List<GameObject> walls;

    public GameObject templateWall;

    public GameObject currentWall;

    public int lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 0 && gameRun)
        {
            if (playerPresent && !wallMoving)
            {
                Debug.Log("A new wall was sent");

                currentWall = Instantiate(walls[Random.Range(0, walls.Count)]);
                currentWall.SetActive(true);

                wallMoving = true;
            }

            _livesTMP.SetText("Lives: " + lives);

            _gameTimer += Time.deltaTime;
            _timerTMP.SetText("Time Left: " + _gameTimer.ToString("F"));
            
            if (_gameTimer >= _gameTime)
            {
                gameRun = false;
                _endTMP.SetText("You Win!");
            }
        }
        else if (lives == 0)
        {
            _livesTMP.SetText("No Lives!");
            _endTMP.SetText("Good try :)");
        }
    }
    
}
