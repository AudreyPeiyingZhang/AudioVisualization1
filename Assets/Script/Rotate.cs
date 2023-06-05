using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 1.0f;
    [SerializeField] private float _minSpeed = 0.0f;
    [SerializeField] private float _handler;
    [SerializeField] private bool _ClockWise;
    [SerializeField] private bool _useEmissionCol = true;
    [SerializeField] private float _maxEmissionCol = 2.0f;
    [SerializeField] private float _minEmssionCol = 1.0f;
    [SerializeField] private float _colorHandler;
    [SerializeField] private Color _col;
   void Start()
    {
        
    }

  
    void Update()
    {
        rotate();
        color();
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

    void color()
    {
        if(_useEmissionCol)
        {
            _colorHandler = Mathf.Lerp(_minEmssionCol, _maxEmissionCol, AudioFloat3Band._averageAmplitude);
            Color _EmissionCol = _col * _colorHandler;
            this.GetComponent<Renderer>().material.color = _EmissionCol;
            

        }
    }
}
