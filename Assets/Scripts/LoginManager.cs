using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private string id;
    private string password;
    private string path;
    private MainManager mainManager;
    public PopupHandler popup;

    private void Start()
    {
        mainManager = MainManager.Instance;
        path = Path.Combine(Application.dataPath, "userData.json");
    }

    public void Login()
    {
        UserDataList userList = LoadData();
        if (userList.users.Find(x => x.id == id) is not null)
        {
            UserData user = userList.users.Find(x => x.id == id);
            if (user.password == password)
            {
                mainManager.id = user.id;
                mainManager.name = user.name;
                mainManager.userName = user.userName;
                SceneManager.LoadScene("ShopList");
                Debug.Log("로그인 성공");
            }
            else
            {
                var seq = DOTween.Sequence();      
    
                seq.Append(transform.DOScale(0.95f, 0.1f));
                seq.Append(transform.DOScale(1.05f, 0.1f));
                seq.Append(transform.DOScale(1f, 0.1f));

                seq.Play().OnComplete(() => {
                    popup.Show();
                });
            }
        }
        else
        {
            var seq = DOTween.Sequence();      
    
            seq.Append(transform.DOScale(0.95f, 0.1f));
            seq.Append(transform.DOScale(1.05f, 0.1f));
            seq.Append(transform.DOScale(1f, 0.1f));

            seq.Play().OnComplete(() => {
                popup.Show();
            });
        }
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
    
    public void SignUp()
    {
        SceneManager.LoadScene("SignUp");
    }

    public void Close()
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().OnComplete(() => {
            popup.Hide();
        });
    }
    
    public void ReadId(string s)
    {
        id = s;
        Debug.Log(id);
    }
    
    public void ReadPassword(string s)
    {
        password = s;
        Debug.Log(password);
    }
}
