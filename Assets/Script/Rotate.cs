using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 1.0f;
    [SerializeField] private float _minSpeed = 0.0f;
    [SerializeField] private float _handler;
    [SerializeField] private bool _ClockWise;

    void Start()
    {
        
    }

  
    void Update()
    {
        rotate();
    }

    void rotate()
    {

        _handler = Mathf.Lerp(_minSpeed, _maxSpeed, AudioFloat3Band._averageAmplitude);
        if(_ClockWise)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 360 * _handler * Time.deltaTime);
        }
        if (!_ClockWise)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -360 * _handler * Time.deltaTime);
        }
    }
}
