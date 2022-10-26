using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    [SerializeField]
    private Collider _playArea;
    
    [SerializeField]
    private PlayAreaController _playAreaController;

    private bool _wallDodged = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _playArea)
        {
            Debug.Log("In play area");
        } else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got hit by the wall");
            _playAreaController.lives--;
            _wallDodged = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _playArea)
        {
            Debug.Log("Wall left play area");
            if (_wallDodged)
            {
                _playAreaController.descriptionTMP.SetText("Dodged!");
            }
            else
            {
                _playAreaController.descriptionTMP.SetText("Ouch!");
                _wallDodged = true;
            }
        }
    }
}
