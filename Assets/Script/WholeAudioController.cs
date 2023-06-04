using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WholeAudioController : MonoBehaviour
{
    public static bool _isUseMicrophone;
    public static bool _isUsePiano;
    public static bool _isUseDefaultMusic;

    public AudioClip _audioClipDefaultMusic;
    AudioSource _audioSource;

    public AudioMixerGroup _audioMixerMaster;
    public AudioMixerGroup _audioMixerMicrophone;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
      
    }

    public void Update()
    {
        checkUseWhichDevice();
        Debug.Log(_isUseDefaultMusic);
    }

    public void checkUseWhichDevice()
    {
        if (!_isUseDefaultMusic)
        {
            _audioSource.outputAudioMixerGroup = _audioMixerMaster;
            _audioSource.clip = _audioClipDefaultMusic;
            _audioSource.Play();
        }
        
        


        if (_isUseMicrophone)
        {
            string[] deviceNames = Microphone.devices;
            if (deviceNames.Length > 0)
            {
                _audioSource.Stop();
                _audioSource.outputAudioMixerGroup = _audioMixerMicrophone;
                _audioSource.clip = Microphone.Start(deviceNames[0], true, 3600 - 1, AudioSettings.outputSampleRate);
                _audioSource.Play();
            }
            else
            {
                _isUseMicrophone = false;
            }
        }
      
        


        if (_isUsePiano)
        {
            _audioSource.outputAudioMixerGroup = _audioMixerMaster;
            _audioSource.clip = null;
        }
        

    }
}