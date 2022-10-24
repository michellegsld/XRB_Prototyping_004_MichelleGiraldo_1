using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private bool _move = false;

    public Vector3 wallDes;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallDes,
                _speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - wallDes.x) <= 0.5f)
            {
                Debug.Log("The wall reached it's destination");
            }
        }
    }
}
