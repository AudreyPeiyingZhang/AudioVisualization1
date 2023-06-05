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
    private float _colHandler;
    [SerializeField] private float _maxEmissionValue = 2.0f;
    [SerializeField] private float _minEmissionValue = 0.0f;
    [SerializeField] private Color _color;
    [SerializeField] private AnimationCurve _animCurve;



    void Start()
    {
        _originalScale = transform.localScale;
    }


    void Update()
    {
        scale();
        emssionCol();
    }

    void scale()
    {
        if (!_useAverage)
        {
            _handler = Mathf.Lerp(_minScale, _maxScale, AudioFloat8Band.audioBandBuffer[_band]);

            Vector3 newScale = _originalScale * _handler;
            this.transform.localScale = newScale;
        }

        if (_useAverage)
        {
            _handler = Mathf.Lerp(_minScale, _maxScale, AudioFloat8Band._averageAmplitudeBuffer);

            Vector3 newScale = _originalScale * _handler;
            this.transform.localScale = newScale;
        }





    }

    void emssionCol()
    {
        if (!_useAverage)
        {
            _colHandler = Mathf.Lerp(_minEmissionValue, _maxEmissionValue, _animCurve.Evaluate(AudioFloat8Band.audioBandBuffer[_band]));
            Color color = _color * _colHandler;
            this.GetComponent<Renderer>().material.color = color;
            

        }

       

    }


}