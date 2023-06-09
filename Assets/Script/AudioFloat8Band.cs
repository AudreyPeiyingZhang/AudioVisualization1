
using UnityEngine;






public class  AudioFloat8Band: MonoBehaviour
{

    
    public static float[] _FrequenciesChannelLeft = new float[512];
    public static float[] _FrequenciesChannelRight = new float[512];
    public static float[] remapSamplesBands = new float[8];
    public static float[] smoothBands = new float[8];
    float[] smoothBandDecrease = new float[8];
    public static float[] audioBand = new float[8];
    public float[] frequencyBandHighest = new float[8];
    public static float[] audioBandBuffer = new float[8];
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
        for (int i = 0;i<8;i++)
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
         * 20 - 60 Hz
         * 60 - 250 Hz
         * 250 - 500 Hz         
         * 500 - 2000 Hz
         * 2000 - 4000 Hz
         * 4000 - 6000 Hz
         * 6000 - 20000 Hz
         * 
         * 
         * NS NOS                Frequency Range      
         * 0 - 2 = 43*2 = 86 Hz [0,86]
         * 1 - 4 = 172 Hz      [87,258]
         * 2 - 8 = 344 Hz     [259,602]
         * 3 - 16 = 688 Hz    [603,1290]
         * 4 - 32 = 1376 Hz   [1291,2666]
         * 5 - 64 =  2752 Hz  [2667, 5418]
         * 6 - 128 = 5504 Hz  [5419,10922]
         * 7 - 256 = 11008 Hz [10923,219930]
         *     510
         *     510+2
         */
        
        int count = 0;
        for (int i = 0; i<8; i++) 
        {
            int remapSamples = 0;
            float average = 0;
            remapSamples = (int)Mathf.Pow(2, i+1);
            if(i == 7)
            {
                remapSamples += 2;

            }
            //Debug.Log(remapSamples);
            for (int j = 0; j < remapSamples; j++)
            {
                if(ChooseChannel == _channels.Stereo)
                {
                    average += _FrequenciesChannelRight[count] + _FrequenciesChannelLeft[count];
                }

                else if(ChooseChannel == _channels.Left)
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

            remapSamplesBands[i] = average*400;



        }



    }



    void smoothReband ()
    {
        for (int i = 0;i<8;i++)
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
        for (int i = 0;i < 8;i++)
        {
            if (remapSamplesBands[i]> frequencyBandHighest[i])
            {
                frequencyBandHighest[i] = remapSamplesBands[i];
            }
            if (frequencyBandHighest[i] != 0)
            {
                audioBand[i] = remapSamplesBands[i] / frequencyBandHighest[i];
                audioBandBuffer[i] = smoothBands[i] / frequencyBandHighest[i];

                
            }
            
        }
        
    }


    void getAllAverageAmplitude()
    {
        

        float _currentAverageAmplitude = 0.0f;
        float _currentAverageAmplitudeBuffer = 0.0f;


        for (int i = 0; i<8; i++)
        {
            _currentAverageAmplitude += audioBand[i];

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

