using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayAreaController : MonoBehaviour
{
   
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
        if (playerPresent && !wallMoving)
        {
            Debug.Log("A new wall was sent");
            
            currentWall = Instantiate(walls[Random.Range(0, walls.Count)]);
            currentWall.SetActive(true);
            
            wallMoving = true;
        }
    }
    
}
