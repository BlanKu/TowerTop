using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelMenuCheckScript : MonoBehaviour
{
    public DataScript dataScript;
    public ButoonScript butoonScript;
    void Start()
    {
        Type type = dataScript.player.GetType();
        FieldInfo field = type.GetField("completedLevels");

        
        if ((int)field.GetValue(dataScript.player) >= butoonScript.condition+1 && gameObject.name == "LevelCompleteCheck")
        {
            gameObject.SetActive(true);
        }
        else if((int)field.GetValue(dataScript.player) > butoonScript.condition-1 && gameObject.name == "LevelLock")
        {
            gameObject.SetActive(false);
        }
        else if ((int)field.GetValue(dataScript.player) <= butoonScript.condition-1 && gameObject.name == "LevelLock")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        

    }
}
