using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class MapManager : MonoBehaviour
{
    public RawImage mapRawImage;

    [Header("맵 정보 설정")]
    public string strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?";
    public double latitude = 35.000;
    public double longitude = 35.000;
    public float zoom = 14.5f;
    public int mapWidth = 1000;
    public int mapHeight = 500;
    private string strAPIKey = ApiKey.Key;

    // Start is called before the first frame update
    void Start()
    {
        mapRawImage = GetComponent<RawImage>();
        StartCoroutine(LoadMap());
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