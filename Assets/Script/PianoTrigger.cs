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
        GetBkeyDown();
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
    public void GetBkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _keyButtons[1].GetComponent<Image>().color = _color;
            _audiosource[1].Play();
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            _keyButtons[1].GetComponent<Image>().color = Color.white;
            _audiosource[1].Stop();
        }

    }
}
