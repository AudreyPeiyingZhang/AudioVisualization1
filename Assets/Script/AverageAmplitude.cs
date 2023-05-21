using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageAmplitude : MonoBehaviour
{
    
    public float scale = 0.5f;
    public bool _isUseBuffer = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        averageAmplitude();
    }

    void averageAmplitude()
    {
        if (_isUseBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, AudioFloat._averageAmplitudeBuffer * scale + 2, transform.localScale.z);
            

            
        }

        else if (!_isUseBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, AudioFloat._averageAmplitude * scale + 2, transform.localScale.z);
            
        }




    }
}
