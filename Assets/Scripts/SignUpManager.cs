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

    // 로그인창으로 돌아가는 메소드
    public void Back()
    {
        SceneManager.LoadScene("Login");
    }
    // shoplist 로 돌아가는 메소드
    public void BackToList()
    {
        SceneManager.LoadScene("ShopList");
    }


    // 가입하기 버튼 클릭시 실행되는 메소드
    public void Continue()
    {
        // 모든 값을 입력해야 회원가입이 된다.
        if (user.id is null || user.password is null || user.name is null)
        {
            Debug.Log("유저 정보 입력 해야함");
        }
        else
        {
            // 유저 데이터를 불러오고 불러온 값에 새로운 유저 정보를 추가하고 저장한다.
            UserDataList existingData = LoadData();
            existingData.users.Add(user);
            SaveData(existingData);

            SceneManager.LoadScene("Login");
        }
    }
    
    // userData 를 불러오는 메소드
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

    // userData를 저장하는 메소드
    private void SaveData(UserDataList data)
    {
        try
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
            Debug.Log("데이터 저장 완료");
        }
        catch (Exception e)
        {
            Debug.LogError("데이터 저장 실패: " + e.Message);
        }
    }

    // 입력한 id를 가져온다
    public void ReadId(string s)
    {
        user.id = s;
        Debug.Log(user.id);
    }
    // 입력한 password를 가져온다
    public void ReadPassword(string s)
    {
        user.password = s;
        Debug.Log(user.password);
    }
    // 입력한 name을 가져온다
    public void ReadName(string s)
    {
        user.name = s;
        Debug.Log(user.name);
    }
    
    // 입력한 username을 가져온다 
    public void ReadUserName(string s)
    {
        user.userName = s;
        Debug.Log(user.userName);
    }
}


