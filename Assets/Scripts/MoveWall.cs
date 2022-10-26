using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private bool _move = true;
    
    [SerializeField]
    private PlayAreaController _playAreaController;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_move && _playAreaController.gameRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(20f, 4.5f, 0f),
                _speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - 20f) <= 0.5f)
            {
                Debug.Log("The wall reached it's destination");
                _move = false;

                _playAreaController.wallMoving = false;
                
                Destroy(this.gameObject);
            }
        } else if (!_playAreaController.gameRun)
        {
            Destroy(this.gameObject);
        }
    }
}
