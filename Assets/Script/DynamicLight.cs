using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLight : MonoBehaviour
{
    //public int setBandNum;
    Light _light;
    
    public float maxIntensity = 50.0f;
    public float minIntensity = 2.0f;
    public float maxSpotAngele = 10.0f;
    public float minSpotAngele = 5.0f;
    public int _bandNumber;
  


    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();

        
    }

    // Update is called once per frame
    void Update()
    {
        manageIntensity();
        manageSpotAngle();
        

    }

    // map Band
   

    void manageIntensity()
    {
   
        _light.intensity = AudioFloat3Band.audioBand3[_bandNumber] * (maxIntensity - minIntensity) + minIntensity;  

    }

    void manageSpotAngle()
    {
        _light.spotAngle = Mathf.Lerp(minSpotAngele, maxSpotAngele, AudioFloat3Band.audioBand3[_bandNumber]);
    }

   
}
