using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class VisualCube : MonoBehaviour
{
    
    public GameObject prefeb;
    public float maxValue = 100000.0f;
    GameObject[] cubes = new GameObject[512];
    public AudioFloat audioFloat;





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
                
                cubes[i].transform.localScale = new Vector3 (1, (audioFloat._FrequenciesChannelRight[i]+ audioFloat._FrequenciesChannelLeft[i]) * maxValue + 1, 1);
            }
        }
    }
}
