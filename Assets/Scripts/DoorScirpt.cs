using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScirpt : MonoBehaviour
{
    SceneVariables _sceneVariables;
    
    void Start()
    {
        _sceneVariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            _sceneVariables.LevelCompete();
        }
    }
}
