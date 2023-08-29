using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    public int highestScore;
    public string recordName;
    public string currentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public int highestScore;
        public string recordName;
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.highestScore;
            recordName = data.recordName;
        }
    }

    public void SaveInfo(int score)
    {
        if (score > highestScore)
        {
            SaveData data = new SaveData();
            data.highestScore = score;
            data.recordName = currentName;
            highestScore = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
}
