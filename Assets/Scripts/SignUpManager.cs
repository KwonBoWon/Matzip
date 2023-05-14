using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SignUpManager : MonoBehaviour
{
    private UserData user;
    private string path;

    private void Start()
    {
        user = new UserData();
        path = Path.Combine(Application.dataPath, "userData.json");
    }

    public void Continue()
    {
        if (user.id is null || user.password is null || user.name is null)
        {
            Debug.Log("유저 정보 입력 해야함");
        }
        else
        {
            string data = JsonUtility.ToJson(user); 
            File.WriteAllText(path, data);
            SceneManager.LoadScene("Login");
        }
    }

    public void ReadId(string s)
    {
        user.id = s;
        Debug.Log(user.id);
    }
    
    public void ReadPassword(string s)
    {
        user.password = s;
        Debug.Log(user.password);
    }
    
    public void ReadName(string s)
    {
        user.name = s;
        Debug.Log(user.name);
    }
    
    public void ReadUserName(string s)
    {
        user.userName = s;
        Debug.Log(user.userName);
    }
}
