using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayAreaController _playAreaController;
    private int _playerPresence = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerPresence > 0)
        {
            _playAreaController.playerPresent = true;
            _playAreaController.gameRun = true;
            Debug.Log("Player Present");
        }
        else
        {
            _playAreaController.playerPresent = false;
            Debug.Log("No player present");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playAreaController.playerPresent = true;
            _playerPresence++;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerPresence--;
        }
    }
}
