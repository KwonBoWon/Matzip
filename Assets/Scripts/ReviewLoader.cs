using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ReviewLoader : MonoBehaviour
{
    public GameObject reviewPrefab;
    private MainManager mainManager;
    private string path;
    private ReviewDataList existingData;
    public GameObject layoutGroup;
    public TextMeshProUGUI reviewCntText;
    public TextMeshProUGUI reviewAvrText;
    private float reviewAvr = 0;
    private int reviewCnt = 0;
    
    void Start()
    {
        mainManager = MainManager.Instance;
        path = Path.Combine(Application.dataPath, "reviewData.json");
        ReviewLoad();
        reviewCntText.text = reviewCnt.ToString() + "개의 리뷰";
    }
    private void ReviewLoad() // 식당에 맞는 리뷰 가져오기
    {
        existingData = LoadData();
        foreach (var item in existingData.reviews)
        {
            if (item.shopName == mainManager.shopName)
            {
                reviewCnt++;
                reviewAvr += item.rating; 
                GameObject temp = Instantiate(reviewPrefab); // 리뷰 프리팹 생서
                Vector3 scale = new Vector3 (0.5625f, 0.5625f, 0.5625f); // 화면 스케일 조정
                temp.transform.localScale = scale;
                
                temp.transform.SetParent(layoutGroup.transform);
                // 리뷰 이름, 내용, 별점 불러오기
                temp.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = item.userName;
                temp.transform.Find("Content").gameObject.GetComponent<TextMeshProUGUI>().text = item.review;
                temp.transform.Find("Rating").gameObject.GetComponent<TextMeshProUGUI>().text = (Mathf.Floor(item.rating * 10) * 0.1f).ToString();
            }
        }
        reviewAvr = (Mathf.Floor(reviewAvr/reviewCnt * 10) * 0.1f);
        reviewAvrText.text = reviewAvr.ToString();
    }
    private ReviewDataList LoadData() // 데이터 로드
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ReviewDataList>(json);
        }
        else
        {
            return new ReviewDataList();
        }
    }
}



[System.Serializable]
public class ReviewData // 리뷰 데이터 형식
{
    public string review;
    public string shopName;
    public string userName;
    public float rating;
}
[System.Serializable]
public class ReviewDataList // 리뷰 데이터들을 담는 클래스
{
    public List<ReviewData> reviews = new List<ReviewData>();
}
