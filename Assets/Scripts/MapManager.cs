using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;
using TMPro;


public class MapManager : MonoBehaviour
{
    public RawImage mapRawImage;
    public TextMeshProUGUI shopName; // shopInfo 씬 식당이름 
    [Header("맵 정보 설정")]
    public string strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?";
    public double latitude = 35.000;
    public double longitude = 35.000;
    public int zoom = 14;
    public int mapWidth = 500;
    public int mapHeight = 500;
    
    private string strAPIKey = ApiKey.Key;
    private string path;
    private ShopDataList shopDataList;

    // Start is called before the first frame update
    void Start()
    {
        mapRawImage = GetComponent<RawImage>();
        
        path = Path.Combine(Application.dataPath, "shopData.json");
        shopDataList = LoadData();
        ShopData shop = shopDataList.shop.Find(x => x.name == MainManager.Instance.shopName);
        latitude = shop.latitude;
        longitude = shop.longitude;
        shopName.text = shop.shopName;
        
        StartCoroutine(LoadMap());
    }
    
    private ShopDataList LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ShopDataList>(json);
        }
        else
        {
            return new ShopDataList();
        }
    }

    IEnumerator LoadMap()
    {
        string url = strBaseURL + "center=" + latitude + "," + longitude +
            "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
            + "&key=" + strAPIKey;   //URL 생성  - 향후 StringBuilder를 이용해 적용.

        Debug.Log("URL : " + url);

        url = UnityWebRequest.UnEscapeURL(url); //Url에 대한  Web 요청
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url); //Texture에 대한 요청 

        yield return req.SendWebRequest();  //요청 전송

        mapRawImage.texture = DownloadHandlerTexture.GetContent(req); // 받은 Texture를 RAW 이미지에 적용
    }

}