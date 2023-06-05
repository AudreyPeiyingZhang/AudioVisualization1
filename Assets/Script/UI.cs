using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button _instrument;
    [SerializeField] private Button _close0;
    [SerializeField] private Button _close1;
    [SerializeField] private Button _close2;
    [SerializeField] private Button _close3;
    [SerializeField] private Button _piano;
    [SerializeField] private Button _beat;
    [SerializeField] private Button _Control;
    [SerializeField] private Toggle _microphoneToggle;
    [SerializeField] private Toggle _instrumentToggle;
    [SerializeField] private Toggle _defaultMusicToggle;
    [SerializeField] private TMP_InputField _angle0;
    [SerializeField] private TMP_InputField _angle1;
    [SerializeField] private TMP_InputField _angle2;
    [SerializeField] private GameObject _PianoOrBeat;
    [SerializeField] private GameObject _PianoPannel;
    [SerializeField] private GameObject _beatPannel;
    [SerializeField] private GameObject _controlPannel;
    [SerializeField] private GameObject _wholeAudioController;
    private string _angle0String;
    [SerializeField] public GameObject _tail0;
    private string _angle1String;
    [SerializeField] public GameObject _tail1;
    private string _angle2String;
    [SerializeField] public GameObject _tail2;


    void Update()
    {
        
        _instrument.onClick.AddListener(setActive);
        _close0.onClick.AddListener(setUnactive);
        _piano.onClick.AddListener(setPianoActive);
        _close1.onClick.AddListener(setPianoUnactive);
        _beat.onClick.AddListener(setBeatActive);
        _close2.onClick.AddListener(setBeatUnactive);
        _Control.onClick.AddListener(setControlPanelActive);
        _close3.onClick.AddListener(setControlPanelUnActive);
        _microphoneToggle.onValueChanged.AddListener(onMicrophoneValueChanged);
        _instrumentToggle.onValueChanged.AddListener(onInstrumentValueChanged);
        _defaultMusicToggle.onValueChanged.AddListener(onDefaultValueChanged);
        _angle0.onEndEdit.AddListener(OnTail0InputFieldEndEdit);
        _angle1.onEndEdit.AddListener(OnTail1InputFieldEndEdit);
        _angle2.onEndEdit.AddListener(OnTail2InputFieldEndEdit);


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

    public void setControlPanelActive()
    {


        _controlPannel.SetActive(true);

    }

    public void setControlPanelUnActive()
    {


        _controlPannel.SetActive(false);

    }

    public void onMicrophoneValueChanged(bool _value = false)
    {


        _wholeAudioController.GetComponent<WholeAudioController>()._isUseMicrophone = _value;


    }

    public void onInstrumentValueChanged(bool _value = false)
    {

        _wholeAudioController.GetComponent<WholeAudioController>()._isUsePiano = _value;

       

    }

    public void onDefaultValueChanged(bool _value = false)
    {

        _wholeAudioController.GetComponent<WholeAudioController>()._isUseDefaultMusic = _value;

        
    }


    private void OnTail0InputFieldEndEdit(string text)
    {
        _angle0String = text;
        float _angle0Degree = float.Parse(_angle0String);
        

        _tail0.GetComponent<CreatePhyllotaxis3Band>()._degree = _angle0Degree;

        //Debug.Log(_tail0.GetComponent<CreatePhyllotaxis3Band>()._degree);



    }
    private void OnTail1InputFieldEndEdit(string text)
    {
        _angle1String = text;
        float _angle1Degree = float.Parse(_angle1String);


        _tail1.GetComponent<CreatePhyllotaxis3Band>()._degree = _angle1Degree;

   



    }

    private void OnTail2InputFieldEndEdit(string text)
    {
        _angle2String = text;
        float _angle2Degree = float.Parse(_angle2String);


        _tail2.GetComponent<CreatePhyllotaxis3Band>()._degree = _angle2Degree;





    }

    /*public void //Update()
    {

        

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
        

    }*/




}
