using UnityEngine;



public class Amplitude512 : MonoBehaviour
{

    public GameObject prefeb;
    public float maxValue = 500.0f;
    public float minValue = 1.0f;
    GameObject[] cubes = new GameObject[512];
    private float _handler;
    private float _colHandler;
    
    public Color _col;

    
        
        
       




    void Start()
    {
        
        for (int i = 0; i < 512; i++)
        {
            GameObject _cloneCubes = Instantiate(prefeb);
            _cloneCubes.transform.position = this.transform.position;
            _cloneCubes.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, 0, 1) * 0.703f * i;
            _cloneCubes.transform.position = new Vector3(0, 1, 0) * 53.0f;
            _cloneCubes.name = "sample" + i;

            cubes[i] = _cloneCubes;
            





        }
    }


    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (cubes[i] != null)
            {
                _handler = Mathf.Lerp(minValue, maxValue, AudioFloat._FrequenciesChannelRight[i] + AudioFloat._FrequenciesChannelLeft[i]);
                cubes[i].transform.localScale = new Vector3(0.7f , 0.7f, 0.7f * _handler);


                _colHandler = Mathf.Lerp(0.8f, 3f, AudioFloat._FrequenciesChannelRight[i] + AudioFloat._FrequenciesChannelLeft[i]);

                Color _dynamicEmission = _col * _colHandler;
                cubes[i].GetComponent<Renderer>().material.color = _dynamicEmission;
              
                    
                    
                    
                   

                

                
            }
        }

        
    }

     
}