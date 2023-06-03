using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

// 모든 씬에서 사용되는 정보들을 저장할 수 있게 싱글톤 패턴으로 작성한 클래스
public class MainManager : MonoBehaviour
{
    // MainManager 를 유일성이 보장되게 한다.
    private static MainManager _instance;
    
    // 유일한 매니저를 갖고 온다
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

    // 초기화
    static void Init()
    {
        if (_instance == null)
        {
            // MainManager 라는 오브젝트가 있는지 확인 후 없으면 만들어준다.
            GameObject go = GameObject.Find("MainManager");
            if (go == null)
            {
                go = new GameObject { name = "MainManager" };
                go.AddComponent<MainManager>();
            }
            
            // 씬을 변경해도 사라지지 않게 DontDestroyOnLoad 함수를 호출한다.
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<MainManager>();
        }
    }
}

