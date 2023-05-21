using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightCubeTest : MonoBehaviour
{
    public int setBandNum;
    public float scale = 5.0f;
    public bool _isUseBuffer = true;
    Material _material;
    public Color _col = Color.black;



    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        cubeScaleReset();
    }


    void cubeScaleReset()
    {
        if (_isUseBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, AudioFloat.audioBandBuffer[setBandNum]*3 + 1, transform.localScale.z);
            Color _color = _col * (AudioFloat.audioBandBuffer[setBandNum]+1);
            
            _material.SetColor ("_Color", _color);
        }

        else if (!_isUseBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, AudioFloat.audioBand[setBandNum] + 1, transform.localScale.z);
            Color _color = _col * (AudioFloat.audioBand[setBandNum] + 1);
            _material.SetColor("_Color", _color);
        }
        
    }

}
