using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEditor.VersionControl;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ReviewLoader : MonoBehaviour
{
    public GameObject reviewPrefab;
    private string path = "reviewData.json"
    //File.AppendAllText(Path.Combine(Application.dataPath, "reviewData.json"), jsonString);
    void Start()
    {
        
    }
    private void ReviewLoad()
    {

    }
    private UserDataList LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<UserDataList>(json);
        }
        else
        {
            return new UserDataList();
        }
    }
}
[System.Serializable]
public class ReviewData
{
    public string review;
    public string shopName;
    public string userName;
    public float rating;
}
[System.Serializable]
public class ReviewDataList
{
    public List<ReviewData> reviews = new List<ReviewData>();
}
