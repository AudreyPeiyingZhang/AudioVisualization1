using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    private AudioSource audioSource;
    public Color _color;
    public Button _button;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        

    }

    void Update()
    {
        GetkeyDown();
    }

    public void GetkeyDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _button.GetComponent<Image>().color = _color;
            audioSource.Play();

            

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _button.GetComponent<Image>().color = Color.white;
           


        }
    }
}