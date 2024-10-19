using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapScipt : MonoBehaviour
{
    public SceneVariables scenevariables;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            scenevariables.GameOver();
        }
    }
}
