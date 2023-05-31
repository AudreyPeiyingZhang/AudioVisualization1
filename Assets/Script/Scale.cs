using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _maxScale = 2.0f;
    [SerializeField] private float _minScale = 1.0f;
    [SerializeField] private float _handler;
    [SerializeField] private int _band;
    private Vector3 _originalScale;
    [SerializeField] private bool _useAverage;


    void Start()
    {
        _originalScale = transform.localScale;
    }


    void Update()
    {
        scale();
    }

    void scale()
    {
        if (!_useAverage)
        {
            _handler = Mathf.Lerp(_minScale, _maxScale, AudioFloat.audioBandBuffer[_band]);

            Vector3 newScale = _originalScale * _handler;
            this.transform.localScale = newScale;
        }

        if (_useAverage)
        {
            _handler = Mathf.Lerp(_minScale, _maxScale, AudioFloat._averageAmplitudeBuffer);

            Vector3 newScale = _originalScale * _handler;
            this.transform.localScale = newScale;
        }





    }
}