using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SceneVariables : MonoBehaviour
{
    public string levelName;
    public int colorDivider;
    public Color color;
    Color colorRGB;

    

    TextMeshProUGUI LevelName;
    Camera Camera;
    Tilemap Map;
    Tilemap Traps;
    SpriteRenderer Door;
    SpriteRenderer Player;
    Image BackgroundLevelName;


    void Start()
    {
        LevelName = GameObject.Find("LevelName").GetComponent<TextMeshProUGUI>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Map = GameObject.Find("Map").GetComponent<Tilemap>();
        Traps = GameObject.Find("Traps").GetComponent<Tilemap>();
        Door = GameObject.Find("Door").GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        BackgroundLevelName = GameObject.Find("BackgroundLevelName").GetComponent<Image>();

        colorRGB = new Color(color.r/colorDivider, color.g/colorDivider, color.b/colorDivider, color.a);

        LevelName.text = levelName;
        Camera.backgroundColor = colorRGB;
        Map.color = color;
        Traps.color = color;
        Door.color = color;
        Player.color = color;
        BackgroundLevelName.color = color;
    }

    
    void Update()
    {
        
    }

    public void LevelCompete()
    {
        Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y);
        Debug.Log("Level Complete [" + levelName + "]");
    }
}
