using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLight : MonoBehaviour
{
    //public int setBandNum;
    Light _light;
    public bool _isUseBuffer = true;
    public float maxIntensity = 100.0f;
    public float minIntensity = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        manageIntensity();

    }

    void manageIntensity()
    {
        
        if (_isUseBuffer)
        {

            _light.intensity = AudioFloat._averageAmplitudeBuffer * (maxIntensity - minIntensity) + minIntensity;

        }

        else if (!_isUseBuffer)
        {
            _light.intensity = AudioFloat._averageAmplitude * (maxIntensity - minIntensity) + minIntensity;
        }

    }



}
