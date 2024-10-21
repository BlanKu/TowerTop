using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    public Player player =  new Player();
    public string gameVersion;

    private void Start()
    {
        LoadData();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SaveData();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }

    }
    public void SaveData()
    {
        string playerData = JsonUtility.ToJson(player);
        string filePath = Application.persistentDataPath + "/playerData.json";

        System.IO.File.WriteAllText(filePath, playerData);

        Debug.Log("PlayerData save to " + filePath);
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/playerData.json";
        string playerData = System.IO.File.ReadAllText(filePath);

        player = JsonUtility.FromJson<Player>(playerData);

        Debug.Log("PlayerData has been loaded");
    }

    [System.Serializable]
    public class Player
    {
        public string sceneName;
        public int completedLevels;
        public float masterVolume;
    }
}
