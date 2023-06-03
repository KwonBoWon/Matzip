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

    // 로그인 버튼 클릭 시 실행되는 메소드
    public void Login()
    {
        // userData.json 에서 리스트를 받아와서 입력한 정보와 비교하여 로그인을 수행한다.
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
                // 로그인 실패시 DOTween을 이용하여 팝업창을 띄우는 코드 
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
            // 로그인 실패시 DOTween을 이용하여 팝업창을 띄우는 코드
            var seq = DOTween.Sequence();      
    
            seq.Append(transform.DOScale(0.95f, 0.1f));
            seq.Append(transform.DOScale(1.05f, 0.1f));
            seq.Append(transform.DOScale(1f, 0.1f));

            seq.Play().OnComplete(() => {
                popup.Show();
            });
        }
    }
    
    // userData.json 에 있는 user 정보를 받아오는 메소드
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
    
    // 회원가입 씬으로 넘기는 메소드
    public void SignUp()
    {
        SceneManager.LoadScene("SignUp");
    }

    
    // 팝업창 닫기 버튼을 클릭했을 때 실행되는 메소드
    public void Close()
    {
        // DOTween 을 이용하여 popup 창을 닫는 코드.
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().OnComplete(() => {
            popup.Hide();
        });
    }
    
    // 입력한 id를 받아온다.
    public void ReadId(string s)
    {
        id = s;
        Debug.Log(id);
    }
    
    // 입력한 password를 받아온다.
    public void ReadPassword(string s)
    {
        password = s;
        Debug.Log(password);
    }
}
