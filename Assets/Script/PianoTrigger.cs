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
        GetQkeyDown();
        GetWkeyDown();
        GetEkeyDown();
        GetRkeyDown();
        GetTkeyDown();
        GetYkeyDown();
        GetUkeyDown();
        GetIkeyDown();
        GetOkeyDown();



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
        }

    }


    public void GetQkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _keyButtons[8].GetComponent<Image>().color = _color;
            _audiosource[8].Play();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _keyButtons[8].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetWkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _keyButtons[9].GetComponent<Image>().color = _color;
            _audiosource[9].Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _keyButtons[9].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetEkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _keyButtons[10].GetComponent<Image>().color = _color;
            _audiosource[10].Play();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _keyButtons[10].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetRkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _keyButtons[11].GetComponent<Image>().color = _color;
            _audiosource[11].Play();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _keyButtons[11].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetTkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _keyButtons[12].GetComponent<Image>().color = _color;
            _audiosource[12].Play();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            _keyButtons[12].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetYkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _keyButtons[13].GetComponent<Image>().color = _color;
            _audiosource[13].Play();
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            _keyButtons[13].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetUkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _keyButtons[14].GetComponent<Image>().color = _color;
            _audiosource[14].Play();
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            _keyButtons[14].GetComponent<Image>().color = Color.white;
        }

    }

    public void GetIkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _keyButtons[15].GetComponent<Image>().color = _color;
            _audiosource[15].Play();
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            _keyButtons[15].GetComponent<Image>().color = Color.white;
        }   

    }


    public void GetOkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _keyButtons[16].GetComponent<Image>().color = _color;
            _audiosource[16].Play();
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            _keyButtons[16].GetComponent<Image>().color = Color.white;
        }

    }
}
