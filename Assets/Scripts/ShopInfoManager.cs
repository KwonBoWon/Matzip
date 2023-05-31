using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopInfoManager : MonoBehaviour
{
    private MainManager mainManager;
    private string shopName;
    public GameObject shopImage1, shopImage2;
    void Start()
    {
        mainManager = MainManager.Instance;
        ShopImageLoad();
    }

    void ShopImageLoad()
    {
        shopName = mainManager.shopName;
        string PATH1 = shopName + "1";
        string PATH2 = shopName + "2";
        // Resources폴더에서 이미지 가져옴
        shopImage1.GetComponent<Image>().sprite = Resources.Load<Sprite>(PATH1);
        shopImage2.GetComponent<Image>().sprite = Resources.Load<Sprite>(PATH2);
    }

}
