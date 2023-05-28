using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.TestTools;

[RequireComponent (typeof(AudioSource))]



public class  AudioFloat3Band: MonoBehaviour
{

    
    public float[] _FrequenciesChannelLeft = new float[512];
    public float[] _FrequenciesChannelRight = new float[512];
    public static float[] remapSamplesBands = new float[3];
    public static float[] smoothBands = new float[3];
    float[] smoothBandDecrease = new float[3];
    public static float[] audioBand3 = new float[3];
    public float[] frequencyBandHighest = new float[3];
    public static float[] audioBandBuffer = new float[3];
    public static float _averageAmplitude;
    public static float _averageAmplitudeBuffer;
    public float _highestAmplitude;
    public float _highestAmplitudeBuffer;
    public float _audioProfile;
    public enum _channels {Stereo, Left,  Right};
    public _channels ChooseChannel = new _channels ();

    public bool _isUseMicrophone = true;
    public AudioClip _audioClipDefaultMusic;
    AudioSource _audioSource;
   
    public bool _isUsePiano = true;
    public AudioClip NoteA;
    public AudioClip NoteB;
    
    public AudioMixerGroup _audioMixerMaster;
    public AudioMixerGroup _audioMixerMicrophone;

   
    


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_isUseMicrophone)

        {
            string[] deviceNames = Microphone.devices;
            if (deviceNames.Length>0)
            {
                _audioSource.outputAudioMixerGroup = _audioMixerMicrophone;

                _audioSource.clip = Microphone.Start(deviceNames[0], true, 3600 -1, AudioSettings.outputSampleRate);
                
            }
            else
            {
                _isUseMicrophone = false;
            }

            
        }

        if (!_isUseMicrophone)
        {
            _audioSource.outputAudioMixerGroup = _audioMixerMaster;

            if(_isUsePiano)
            {
                _audioSource.clip = null;
                
            }
            if(!_isUsePiano)
            {
                

                _audioSource.clip = _audioClipDefaultMusic;

            }
            
           

        }



        _audioSource.Play();

        setAudioProfile(_audioProfile);

    }


    
    
    void Update()
    {

        GenerateNote();
        getSpectrumData();
        reMapBand();
        smoothReband();
        createAudioBand();
        getAllAverageAmplitude();


    }


    void GenerateNote()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            _audioSource.clip = NoteA;
            _audioSource.Play();
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            _audioSource.clip = NoteB;
            _audioSource.Play();
        }

    }

    

    void setAudioProfile(float AudioProfile)
    {
        for (int i = 0;i<2;i++)
        {
            frequencyBandHighest[i] = AudioProfile;

        }
    }

    void getSpectrumData()
    {
        
        _audioSource.GetSpectrumData(_FrequenciesChannelLeft, 0, FFTWindow.Blackman);
        _audioSource.GetSpectrumData(_FrequenciesChannelRight, 1, FFTWindow.Blackman);

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
         *0-600
         * 600-3600
         * 3600-17800
         * 
         * 14:84:414
         * 
         */

        int count = 0;
        for (int i = 0; i<3; i++) 
        {
            float average = 0;

            int remapSamples = (int)(Mathf.Pow(3, i)) * 14;

            if(i==1)
            {
                remapSamples *= 2;
            }
            if (i == 2)
            {
                remapSamples += 288;
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
            remapSamplesBands[i] = average * 400;
            //Debug.Log(remapSamplesBands[0] + "," + remapSamplesBands[1] + "," + remapSamplesBands[2]);

        }



    }



    void smoothReband ()
    {
        for (int i = 0;i<3;i++)
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
        for (int i = 0;i < 3;i++)
        {
            if (remapSamplesBands[i]> frequencyBandHighest[i])
            {
                frequencyBandHighest[i] = remapSamplesBands[i];
            }
            if (frequencyBandHighest[i] != 0)
            {
                audioBand3[i] = remapSamplesBands[i] / frequencyBandHighest[i];
                audioBandBuffer[i] = smoothBands[i] / frequencyBandHighest[i];
            }

            //Debug.Log(audioBand3[0] + "," + audioBand3[1] + "," + audioBand3[2]);
        }
        
    }


    void getAllAverageAmplitude()
    {
        

        float _currentAverageAmplitude = 0.0f;
        float _currentAverageAmplitudeBuffer = 0.0f;


        for (int i = 0; i<3; i++)
        {
            _currentAverageAmplitude += audioBand3[i];

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

