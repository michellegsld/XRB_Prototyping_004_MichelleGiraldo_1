using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float _threshold = .1f;
    [SerializeField] private float _deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    
    public UnityEvent onPressed, onReleased;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + _threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - _threshold <= 0)
            Release();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < _deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log(gameObject.ToString() + " is pressed.");
    }

    private void Release()
    {
        _isPressed = false;
        onPressed.Invoke();
        Debug.Log(gameObject.ToString() + " is released.");
    }
}
