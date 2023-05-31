using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class VisualCube : MonoBehaviour
{
    
    public GameObject prefeb;
    public float maxValue = 5.0f;
    public float minValue = 1.0f;
    GameObject[] cubes = new GameObject[512];
    
    private Vector3[] _originalScale;
    private float _handler;






    void Start()
    {
        
        for (int i = 0; i< 512; i++)
        {
            
            GameObject _cloneCubes = Instantiate(prefeb);
            _cloneCubes.transform.position = this.transform.position;
            _cloneCubes.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, 1, 0) * 0.703f * i;
            _cloneCubes.transform.position = new Vector3(0,0,1) * 100;
            _cloneCubes.name = "sample" + i;

            cubes[i] = _cloneCubes;
            




        }
    }

    
    void Update()
    {
        for(int i = 0;i<512; i++)
        {
            if (cubes[i]!= null)
            {
                _originalScale[i] = cubes[i].transform.localScale;
                _handler = Mathf.Lerp(minValue, maxValue, AudioFloat._FrequenciesChannelRight[i] + AudioFloat._FrequenciesChannelLeft[i]);


                Vector3 _newScale = new Vector3 (_originalScale[i].x * _handler, _originalScale[i].y, _originalScale[i].z);
                cubes[i].transform.localScale = _newScale;
                Debug.Log(_newScale);
            }
        }
    }
}
