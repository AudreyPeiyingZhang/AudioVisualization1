using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public RawImage colorPicker;
    public GameObject _gameObject;
    public Camera _mainCamera;
    private Texture2D _mainTexture;
    public Slider _slider;
    public float _hueValue;

    

    private void Update()
    {
        setHue();

        setTexture();

        useMouseGetCol();
    }

    void setHue()
    {

        _slider.maxValue = 1.0f;
        _slider.minValue = 0.0f;
        _hueValue = _slider.value;



    }
    void setTexture()
    {

        _mainTexture = new Texture2D(16, 16);
        _mainTexture.wrapMode = TextureWrapMode.Clamp;
        for (int x = 0; x<_mainTexture.width; x++)
        {
            for(int y = 0; y < _mainTexture.height; y++)
            {
                _mainTexture.SetPixel (x, y, Color.HSVToRGB(_hueValue, (float)x/ _mainTexture.width, (float)y / _mainTexture.height));
            }
        }
        _mainTexture.Apply();

        colorPicker.texture = _mainTexture;


    }
    
    void useMouseGetCol()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                colorPicker.rectTransform,
                Input.mousePosition,
                _mainCamera,
                out Vector2 localCursor
            );


            colorPicker.texture = _mainTexture;

            Color pickedColor = _mainTexture.GetPixel((int)localCursor.x, (int)localCursor.y);
            
            _gameObject.GetComponent<Renderer>().material.color = pickedColor;

        }

    }
    
}
