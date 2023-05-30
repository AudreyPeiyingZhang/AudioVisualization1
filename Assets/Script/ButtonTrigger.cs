using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent _usePianoKey;

    // Start is called before the first frame update
    void Start()
    {
        _usePianoKey.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
       
       
       
        


    }
}
