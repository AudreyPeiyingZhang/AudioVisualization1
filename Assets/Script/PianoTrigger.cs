using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PianoTrigger : MonoBehaviour
{
    

    [SerializeField] private Button[] _keyButtons;
    
    public static Color _color = new Color(0,1,0,1);
    public AudioSource[] _audiosource;


    void Start()
    {
        
    }

    void Update()
    {
        GetAkeyDown();
        GetSkeyDown();
        GetDkeyDown();
        GetFkeyDown();
        GetGkeyDown();
        GetHkeyDown();
        GetJkeyDown();
        GetKkeyDown();

       
    }
    public void GetAkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _keyButtons[0].GetComponent<Image>().color = _color;
            _audiosource[0].Play();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _keyButtons[0].GetComponent<Image>().color = Color.white;
            _audiosource[0].Stop();
        }
        
    }
    public void GetSkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _keyButtons[1].GetComponent<Image>().color = _color;
            _audiosource[1].Play();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _keyButtons[1].GetComponent<Image>().color = Color.white;
            _audiosource[1].Stop();
        }

    }

    public void GetDkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _keyButtons[2].GetComponent<Image>().color = _color;
            _audiosource[2].Play();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _keyButtons[2].GetComponent<Image>().color = Color.white;
            _audiosource[2].Stop();
        }

    }

    public void GetFkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _keyButtons[3].GetComponent<Image>().color = _color;
            _audiosource[3].Play();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            _keyButtons[3].GetComponent<Image>().color = Color.white;
            _audiosource[3].Stop();
        }

    }

    public void GetGkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _keyButtons[4].GetComponent<Image>().color = _color;
            _audiosource[4].Play();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            _keyButtons[4].GetComponent<Image>().color = Color.white;
            _audiosource[4].Stop();
        }

    }

    public void GetHkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _keyButtons[5].GetComponent<Image>().color = _color;
            _audiosource[5].Play();
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            _keyButtons[5].GetComponent<Image>().color = Color.white;
            _audiosource[5].Stop();
        }

    }

    public void GetJkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _keyButtons[6].GetComponent<Image>().color = _color;
            _audiosource[6].Play();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            _keyButtons[6].GetComponent<Image>().color = Color.white;
            _audiosource[6].Stop();
        }

    }

    public void GetKkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _keyButtons[7].GetComponent<Image>().color = _color;
            _audiosource[7].Play();
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            _keyButtons[7].GetComponent<Image>().color = Color.white;
            _audiosource[7].Stop();
        }

    }
}
