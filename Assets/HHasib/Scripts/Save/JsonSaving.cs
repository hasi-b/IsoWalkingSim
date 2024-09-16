using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class JsonSaving : MonoBehaviour
{

    public static JsonSaving instance;

    PlayerData playerData;

    string path = "";
    string persistentPath = "";




    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPaths();
    }



    public void CreateNewPlayerData(NPC.NPC_Name npc, bool isQuestDone, NPC_Class.NpcState npcState)
    {
        playerData = new PlayerData(npc,isQuestDone,npcState);
        SaveData();

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        string savePath = path;
        Debug.Log("Saving Data at "+ savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }


    public PlayerData LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        return data;
    }

}
