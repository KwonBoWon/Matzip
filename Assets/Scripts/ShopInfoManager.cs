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

    void ShopImageLoad() // Resources폴더에서 식당에 맞는 이미지 두개 가져옴
    {
        shopName = mainManager.shopName;
        string PATH1 = shopName + "1";
        string PATH2 = shopName + "2";

        shopImage1.GetComponent<Image>().sprite = Resources.Load<Sprite>(PATH1);
        shopImage2.GetComponent<Image>().sprite = Resources.Load<Sprite>(PATH2);
    }
    

}
