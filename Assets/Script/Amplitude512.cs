using UnityEngine;



public class Amplitude512 : MonoBehaviour
{

    public GameObject prefeb;
    public float maxValue = 500.0f;
    public float minValue = 1.0f;
    GameObject[] cubes = new GameObject[64];
    private float _handler;
    private float _colHandler;
    
    public Color _col;

    
        
        
       




    void Start()
    {
        
        for (int i = 0; i < 64; i++)
        {
            GameObject _cloneCubes = Instantiate(prefeb);
            _cloneCubes.transform.position = this.transform.position;
            _cloneCubes.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, 0, 1) * 5.625f * i;
            _cloneCubes.transform.position = new Vector3(0, 1, 0) * 53.0f;
            _cloneCubes.name = "sample" + i;

            cubes[i] = _cloneCubes;
            





        }
    }


    void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if (cubes[i] != null)
            {
                _handler = Mathf.Lerp(minValue, maxValue, AudioFloat64Band.audioBand64[i]);
                cubes[i].transform.localScale = new Vector3(1.0f , 1.0f, 0.3f * _handler);


                _colHandler = Mathf.Lerp(0.8f, 3f, AudioFloat64Band.audioBand64[i]);

                Color _dynamicEmission = _col * _colHandler;
                cubes[i].GetComponent<Renderer>().material.color = _dynamicEmission;
              
                    
                    
                    
                   

                

                
            }
        }

        
    }

     
}