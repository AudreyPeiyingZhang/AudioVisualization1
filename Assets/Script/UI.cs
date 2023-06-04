using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button _instrument;
    [SerializeField] private Button _close0;
    [SerializeField] private Button _close1;
    [SerializeField] private Button _close2;
    [SerializeField] private Button _piano;
    [SerializeField] private Button _beat;
    [SerializeField] private Toggle _microphoneToggle;
    [SerializeField] private Toggle _instrumentToggle;
    [SerializeField] private Toggle _defaultMusicToggle;
    [SerializeField] private GameObject _PianoOrBeat;
    [SerializeField] private GameObject _PianoPannel;
    [SerializeField] private GameObject _beatPannel;
    


    void Start()
    {
        
        _instrument.onClick.AddListener(setActive);
        _close0.onClick.AddListener(setUnactive);
        _piano.onClick.AddListener(setPianoActive);
        _close1.onClick.AddListener(setPianoUnactive);
        _beat.onClick.AddListener(setBeatActive);
        _close2.onClick.AddListener(setBeatUnactive);
       

    }



    public void setActive()
    {

        _PianoOrBeat.SetActive(true);

    }

    public void setUnactive()
    {
        _PianoOrBeat.SetActive(false);
    }

    public void setPianoActive()
    {


        _PianoPannel.SetActive(true);
        _PianoOrBeat.SetActive(false);
    }

    public void setPianoUnactive()
    {


        _PianoPannel.SetActive(false);
        
    }
    public void setBeatActive()
    {


        _beatPannel.SetActive(true);
        _PianoOrBeat.SetActive(false);
    }

    public void setBeatUnactive()
    {


        _beatPannel.SetActive(false);

    }

    public void Update()
    {
        if(_microphoneToggle.isOn)
        {
            WholeAudioController._isUseMicrophone = true;
        }
        if(!_microphoneToggle.isOn)
        {
            WholeAudioController._isUseMicrophone = false;
        }

        //

        if(_instrumentToggle.isOn)
        {
            WholeAudioController._isUsePiano = true;
        }
       

        if(!_instrumentToggle.isOn)
        {
            WholeAudioController._isUsePiano = false;

        }

        if(_defaultMusicToggle.isOn)
        {
            WholeAudioController._isUseDefaultMusic = true;

        }
        if (!_defaultMusicToggle.isOn)
        {
            WholeAudioController._isUseDefaultMusic = false;

        }
        //Debug.Log(WholeAudioController._isUseDefaultMusic);

    }

    


}
