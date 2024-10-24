using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GetColorScript : MonoBehaviour
{
    public bool mapColor, objectsColor, cameraColorBackground;

    private SpriteRenderer _ObjectSpriteRender;
    private SceneVariables _SceneVariables;
    private Camera _Camera;
    

    void Start()
    {
        _SceneVariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();

        if(_SceneVariables == mapColor)
        {
            _ObjectSpriteRender = gameObject.GetComponent<SpriteRenderer>();
            _ObjectSpriteRender.color = _SceneVariables.mapColor;
        }
        else if (_SceneVariables == objectsColor)
        {
            _ObjectSpriteRender = gameObject.GetComponent<SpriteRenderer>();
            _ObjectSpriteRender.color = _SceneVariables.objectsColors;
        }
        else if (_SceneVariables == cameraColorBackground)
        {
            _Camera = gameObject.GetComponent<Camera>();
            _Camera.backgroundColor = _SceneVariables.cameraBackgroundColor;
        }
    }
}
