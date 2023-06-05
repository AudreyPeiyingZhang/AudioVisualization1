using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WholeAudioController : MonoBehaviour
{
    public bool _isUseMicrophone = false;
    public bool _isUsePiano = false;
    public bool _isUseDefaultMusic = false;

    public AudioClip _audioClipDefaultMusic;
    AudioSource _audioSource;

    public AudioMixerGroup _audioMixerMaster;
    public AudioMixerGroup _audioMixerMicrophone;
     
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
       

    }


    void Update()
    {
        
        checkUseWhichDevice();
        Debug.Log(_audioSource.clip);
    }



    public void checkUseWhichDevice()
    {
        if (!_isUseDefaultMusic)
        {
            _audioSource.outputAudioMixerGroup = _audioMixerMaster;
            _audioSource.clip = _audioClipDefaultMusic;
            _audioSource.Play(0);
        }
        
        


        if (_isUseMicrophone)
        {
            _audioSource.Stop();
            _audioSource.outputAudioMixerGroup = _audioMixerMicrophone;
            
            _audioSource.clip = Microphone.Start(Microphone.devices[0], true, 3600 - 1, AudioSettings.outputSampleRate);
            _audioSource.Play(0);



        }
      
        


        if (_isUsePiano)
        {
            _audioSource.outputAudioMixerGroup = _audioMixerMaster;
            _audioSource.clip = null;
        }

        
    }
}