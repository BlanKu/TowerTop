using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SceneVariables : MonoBehaviour
{
    public string levelName;
    public string nextLevelName;
    public int valueAfterCompleteLevel;
    public Color mapColor = new Color(47, 47, 47, 255);
    public Color objectsColors = new Color(255, 255, 255, 255);
    public Color cameraBackgroundColor = new Color(18, 18, 18, 255);

    SpriteRenderer Door;
    SpriteRenderer Player;

    PlayerScript PlayerScript;
    public DataScript DataScript;
    public LoadingScirpt LoadingScirpt;


    void Start()
    {
        DataScript.LoadData();
        AudioListener.volume = DataScript.player.masterVolume;

        GameObject.Find("LevelName").GetComponent<TextMeshProUGUI>().text = levelName;

        Door = GameObject.Find("Door").GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        PlayerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void LevelCompete()
    {
        Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y);
        PlayerScript._rigidbody2D.velocity = new Vector2(0,0);
        PlayerScript.playerCanMove = false;
        DataScript.player.completedLevels = valueAfterCompleteLevel;
        DataScript.SaveData();
        Debug.Log("Level Complete [" + levelName + "]");
        StartCoroutine(LoadingScirpt.Loading());
    }

    public void GameOver()
    {
        PlayerScript.PlayGameOver();
        StartCoroutine(LoadingScirpt.LoadingGameOver());
    }
}
