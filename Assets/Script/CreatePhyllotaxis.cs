using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePhyllotaxis : MonoBehaviour
{
    
    public GameObject _dot;
    public float _degree, _dotScale, _c;
    public int _n;
    private Vector2 calculatePhyllotaxis (float Degree, float N, float C)
    {
        float _angle = N * (Degree*Mathf.Deg2Rad);
        float _r = C * Mathf.Sqrt(N);
        float _X = _r * Mathf.Cos(_angle);
        float _Y = _r * Mathf.Sin(_angle);
        Vector2 _pos = new Vector2(_X, _Y);
        return _pos;

    }
    private Vector2 setPhyllotaxisPos;




    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            
                setPhyllotaxisPos = calculatePhyllotaxis(_degree, _n, _c);
                GameObject _dotInstantiate = Instantiate(_dot);
                _dotInstantiate.transform.position = setPhyllotaxisPos;
                _dotInstantiate.transform.localScale = new Vector3(_dotScale, _dotScale, _dotScale);
                _n++;
            
            

        }
    }
}
