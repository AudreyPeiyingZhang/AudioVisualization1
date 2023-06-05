using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.TestTools;
using UnityEngine.UI;





public class  AudioFloat64Band: MonoBehaviour
{

    
    public float[] _FrequenciesChannelLeft = new float[512];
    public float[] _FrequenciesChannelRight = new float[512];
    public static float[] remapSamplesBands = new float[64];
    public static float[] smoothBands = new float[64];
    float[] smoothBandDecrease = new float[64];
    public static float[] audioBand64 = new float[64];
    public float[] frequencyBandHighest = new float[64];
    public static float[] audioBandBuffer = new float[64];


    public static float _averageAmplitude;
    public static float _averageAmplitudeBuffer;
    public float _highestAmplitude;
    public float _highestAmplitudeBuffer;
    public float _audioProfile;
    public enum _channels {Stereo, Left,  Right};
    public _channels ChooseChannel = new _channels ();



   
    


    void Awake()
    {
       
        
     
        

       

        setAudioProfile(_audioProfile);

    }


    
    
    void Update()
    {


        
        getSpectrumData();
        reMapBand();
        smoothReband();
        createAudioBand();
        getAllAverageAmplitude();
        


    }


    

  


    void setAudioProfile(float AudioProfile)
    {
        for (int i = 0;i<64;i++)
        {
            frequencyBandHighest[i] = AudioProfile;

        }
    }

    void getSpectrumData()
    {

        AudioListener.GetSpectrumData(_FrequenciesChannelLeft, 0, FFTWindow.Blackman);
        AudioListener.GetSpectrumData(_FrequenciesChannelRight, 1, FFTWindow.Blackman);

    }
    void reMapBand()
    {
        /*
         * max sample rate = 22050 Hz
         * the length of samples representes the number of frequency bands
         * the exact value of each sample represents the magnitude of amplitude 
         * the frequency range that each sample contains is 22050/512 = 43 Hz
         * But the most of the voice that we can hear are in the range of 60-10k
         * remap it with eight samples
         * NS - NewSamples
         * NOS - NumberofOldSamples
         * 
         * 
       
         * 
         */

        int count = 0;
        int remapSamples = 1;
        int power = 0;


        for (int i = 0; i<64; i++) 
        {
            float average = 0;

            //int remapSamples = (int)(Mathf.Pow(3, i)) * 14;

            if (i == 16 || i == 32 || i == 40 || i == 48 || i == 56)
            {
                power++;
                remapSamples = (int)Mathf.Pow(2, power);
                if(power == 3)
                {
                    remapSamples -= 2;
                }
            }

            for (int j =0; j< remapSamples; j++)
            {

                if (ChooseChannel == _channels.Stereo)
                {
                    average += _FrequenciesChannelRight[count] + _FrequenciesChannelLeft[count];
                }

                else if (ChooseChannel == _channels.Left)
                {
                    average += _FrequenciesChannelLeft[count];
                }
                else if (ChooseChannel == _channels.Right)
                {
                    average += _FrequenciesChannelRight[count];
                }
                count++;

            }

            average /= remapSamples;
            remapSamplesBands[i] = average * 80;
            //Debug.Log(remapSamplesBands[0] + "," + remapSamplesBands[1] + "," + remapSamplesBands[2]);

        }



    }



    void smoothReband ()
    {
        for (int i = 0;i<64;i++)
        {
            if(remapSamplesBands[i] > smoothBands[i])
            {
                smoothBands[i] = remapSamplesBands[i];
                smoothBandDecrease[i] = 0.0005f;

            }
            else if (remapSamplesBands[i] < smoothBands[i])
            {
                //smoothBandDecrease[i] = (smoothBands[i] - remapSamplesBands[i])/8;
                smoothBands[i] -= smoothBandDecrease[i];
                smoothBandDecrease[i] *= 1.2f;



            }




        }




    }


    void createAudioBand()
    {
        for (int i = 0;i < 64;i++)
        {
            if (remapSamplesBands[i]> frequencyBandHighest[i])
            {
                frequencyBandHighest[i] = remapSamplesBands[i];
            }
            if (frequencyBandHighest[i] != 0)
            {
                audioBand64[i] = remapSamplesBands[i] / frequencyBandHighest[i];
                audioBandBuffer[i] = smoothBands[i] / frequencyBandHighest[i];
            }

            //Debug.Log(audioBand64[0] + "," + audioBand64[1] + "," + audioBand64[2]);
        }
        
    }


    void getAllAverageAmplitude()
    {
        

        float _currentAverageAmplitude = 0.0f;
        float _currentAverageAmplitudeBuffer = 0.0f;


        for (int i = 0; i<64; i++)
        {
            _currentAverageAmplitude += audioBand64[i];

            _currentAverageAmplitudeBuffer += audioBandBuffer[i];
        }

        if(_currentAverageAmplitude > _highestAmplitude)
        {
            _highestAmplitude = _currentAverageAmplitude;
        }

        if (_currentAverageAmplitudeBuffer > _highestAmplitudeBuffer)
        {
            _highestAmplitudeBuffer = _currentAverageAmplitudeBuffer;
        }


        if (_highestAmplitude != 0)
        {
            _averageAmplitude = _currentAverageAmplitude / _highestAmplitude;
            _averageAmplitudeBuffer = _currentAverageAmplitudeBuffer / _highestAmplitudeBuffer;
        }
        

        


    }


    
}

