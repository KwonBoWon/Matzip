using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private static MainManager _instance;

    public static MainManager Instance
    {
        get { Init(); return _instance; }
    }

    public string id;
    public string name;
    public string realShopName;
    public string userName;
    public string shopName;

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("MainManager");
            if (go == null)
            {
                go = new GameObject { name = "MainManager" };
                go.AddComponent<MainManager>();
            }
            
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<MainManager>();
        }
    }
}

