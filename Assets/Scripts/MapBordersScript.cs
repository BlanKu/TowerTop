using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBordersScript : MonoBehaviour
{
    SceneVariables _sceneVariables;

    private void Start()
    {
        _sceneVariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            _sceneVariables.GameOver();
        }
    }
}
