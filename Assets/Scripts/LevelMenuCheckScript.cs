using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelMenuCheckScript : MonoBehaviour
{
    public DataScript dataScript;
    public int condition;
    void Start()
    {
        Type type = dataScript.player.GetType();
        FieldInfo field = type.GetField("completedLevels");

        if((int)field.GetValue(dataScript.player) >= condition)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
