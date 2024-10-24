using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private SceneVariables _SceneVariables;

    private void Start()
    {
        _SceneVariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "Player")
        {
            _SceneVariables.GameOver();
            Destroy(gameObject);
        }
    }
}
