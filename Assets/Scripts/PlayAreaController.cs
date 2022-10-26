using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayAreaController : MonoBehaviour
{
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

                descriptionTMP.SetText("Dodge!");

                currentWall = Instantiate(walls[Random.Range(0, walls.Count)]);
                currentWall.SetActive(true);

                wallMoving = true;
            }

            _livesTMP.SetText("Lives: " + lives);

            _gameTimer += Time.deltaTime;
            _timerTMP.SetText("Time Left: " + (60.0f - _gameTimer).ToString("F"));
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
    
}
