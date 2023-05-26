using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatePhyllotaxis3Band : MonoBehaviour
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
    public Vector2 _lerpSpeedMinMax;
    public AnimationCurve _lerpPosAnimCurve;
    public int _lerpPosBand;


    //stepsize
    public int _stepSize;
    private int _currentIteration;
    public int _MaxInteration;

    //Color 
    private Material _trailMaterial;
    public Color _color;

    //Forward  Inverse repeat
    private bool _Forward;
    public bool _Repeat;
    public bool _Inverse;

    //scale
    public bool _useScale;
    public bool _useLinearScale;
    public bool _useScaleAnimCurve;
    public Vector2 _scaleMinMax;
    private float _currentScale;
    public int _scaleBand;
    public float _scaleAnimSpeed;
    private float _scaleAnimTimer;
    public AnimationCurve _scaleAnimCurve;




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


        setPhyllotaxisPos = calculatePhyllotaxis(_degree, _number, _currentScale);
        _startPosition = transform.localPosition;
        _endPositon = new Vector2(setPhyllotaxisPos.x, setPhyllotaxisPos.y);

    }

    void Awake()
    {

        _currentScale = _Scale;
        _Forward = true;
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailMaterial = new Material(_trailRenderer.material);
        _trailMaterial.SetColor("_TintColor", _color);
        _trailRenderer.material = _trailMaterial;

        _number = _numberOfStart;
        transform.localPosition = calculatePhyllotaxis(_degree, _number, _currentScale);

        if (_isUseLerp)
        {
            _isLerp = true;
            setLerpingPosition();

        }


        enabled = true;

    }
    private void Update()
    {
        if(_useScale)
        {
            

            if(_useScaleAnimCurve)
            {
                _scaleAnimTimer += (_scaleAnimSpeed * AudioFloat3Band.audioBand3[_scaleBand]) * Time.deltaTime;
                if(_scaleAnimTimer>=1)
                {
                    _scaleAnimTimer -= 1;
                }



               _currentScale = Mathf.Lerp(_scaleMinMax.x, _scaleMinMax.y, _scaleAnimCurve.Evaluate(_scaleAnimTimer));



            }

            if (_useLinearScale)
            {
                _currentScale = Mathf.Lerp(_scaleMinMax.x, _scaleMinMax.y, AudioFloat3Band.audioBand3[_scaleBand]);

            }








        }








        if (_isUseLerp)
        {

            if (_isLerp)
            {
                _lerpSpeed = Mathf.Lerp(_lerpSpeedMinMax.x, _lerpSpeedMinMax.y, _lerpPosAnimCurve.Evaluate(AudioFloat3Band.audioBand3[_lerpPosBand]));
                //Debug.Log((AudioFloat.audioBand3[0])+","+ (AudioFloat.audioBand3[1]) + "," + (AudioFloat.audioBand3[2]));
                _lerpTimer += Time.deltaTime * _lerpSpeed;

                transform.localPosition = Vector3.Lerp(_startPosition, _endPositon, Mathf.Clamp01(_lerpTimer));
                if (_lerpTimer > 1)
                {
                    _lerpTimer -= 1;

                    if(_Forward)
                    {
                        _number += _stepSize;
                        _currentIteration++;
                    }

                    else
                    {
                        _number -= _stepSize;
                        _currentIteration--;
                    }

                    if ( _currentIteration > 0 && _currentIteration < _MaxInteration)
                    {
                        setLerpingPosition();
                    }

                    else

                    {
                        if(_Repeat)
                        {
                            if(_Inverse)
                            {
                                _Forward = !_Forward;
                                setLerpingPosition();
                            }

                            else
                            {
                                _number = _numberOfStart;
                                _currentIteration = 0;
                                setLerpingPosition();
                            }
                            

                        }

                        else
                        {
                            _isLerp = false;

                        }

                        

                    }

                    
                    



                }


            }


        }

        if (!_isUseLerp)
        {
            setPhyllotaxisPos = calculatePhyllotaxis(_degree, _number, _currentScale);
            transform.localPosition = new Vector2(setPhyllotaxisPos.x, setPhyllotaxisPos.y);
            _number += _stepSize;
            _currentIteration++;
        }
    }

}