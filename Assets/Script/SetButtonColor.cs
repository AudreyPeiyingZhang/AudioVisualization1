

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetButtonColor : MonoBehaviour
{


    [SerializeField] private Button _Button;
    void Update()
    {
        _Button.onClick.AddListener(changeColor);
       
    }




    public void changeColor()
    {
        _Button.GetComponent<Image>().color = PianoTrigger._color;
        

    }
}