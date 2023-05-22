using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPhyllotaxis : MonoBehaviour
{

    //PhyllotaxisFormularPara
    public float _degree, _Scale;
    public int _numberOfStart;
    private int _number;

    //Trail
    private TrailRenderer _trailRenderer;

    //Lerping
    private Vector2 _startPosition, _endPositon;
    private float _lerpDistance;
    public bool _isUseLerp = true;
    private bool _isLerp;
    private float _lerpSpeed, _lerpTimer;
    public Vector2 _lerpSpeedMaxMin;
    public AnimationCurve _lerpPosAnimCurve;
    public int _lerpPosBand;


    //stepsize
    public int _stepSize;
    private int _currentIteration;
    public int _MaxInteration;

    //Color 
    private Material _trailMaterial;
    public Color _color;

    //Audio input
    //public AudioFloat _audiofloat;

    //Positions
    private Vector2 calculatePhyllotaxis(float Degree, float Number, float Scale)
    {
        float _angle = Number * (Degree * Mathf.Deg2Rad);
        float _r = Scale * Mathf.Sqrt(Number);
        float _X = _r * Mathf.Cos(_angle);
        float _Y = _r * Mathf.Sin(_angle);
        Vector2 _pos = new Vector2(_X, _Y);
        return _pos;

    }
    private Vector2 setPhyllotaxisPos;


    void setLerpingPosition()
    {


        setPhyllotaxisPos = calculatePhyllotaxis(_degree, _number, _Scale);
        _startPosition = transform.localPosition;
        _endPositon = new Vector2(setPhyllotaxisPos.x, setPhyllotaxisPos.y);

    }

    void Awake()
    {

        _trailRenderer = GetComponent<TrailRenderer>();
        _trailMaterial = new Material(_trailRenderer.material);
        _trailMaterial.SetColor("_TintColor", _color);
        _trailRenderer.material = _trailMaterial;

        _number = _numberOfStart;
        transform.localPosition = calculatePhyllotaxis(_degree, _number, _Scale);

        if (_isUseLerp)
        {
            _isLerp = true;
            setLerpingPosition();

        }


        enabled = true;

    }
    void Start()
    {
        if (_isUseLerp)
        {

            if (_isLerp)
            {
                _lerpSpeed = Mathf.Lerp(_lerpSpeedMaxMin.x, _lerpSpeedMaxMin.y, _lerpPosAnimCurve.Evaluate(AudioFloat.audioBand[_lerpPosBand]));
                _lerpTimer += Time.deltaTime* _lerpSpeed;
                transform.localPosition = Vector3.Lerp(_startPosition, _endPositon, _lerpTimer);
                if(_lerpTimer>1)
                {
                    _lerpTimer -= 1;
                    setLerpingPosition();
                    _number += _stepSize;
                    _currentIteration++;
                    Debug.Log(transform.localPosition);
                   

                }


            }


        }

        if (!_isUseLerp)
        {
            setPhyllotaxisPos = calculatePhyllotaxis(_degree, _number, _Scale);
            transform.localPosition = new Vector3(setPhyllotaxisPos.x, setPhyllotaxisPos.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }
    }

}