using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEditor.VersionControl;
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
    private void ReviewLoad()
    {
        existingData = LoadData();
        foreach (var item in existingData.reviews)
        {
            if (item.shopName == mainManager.shopName)
            {
                reviewCnt++;
                reviewAvr += item.rating;
                GameObject temp = Instantiate(reviewPrefab);
                temp.transform.SetParent(layoutGroup.transform);
                temp.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = item.userName;
                temp.transform.Find("Content").gameObject.GetComponent<TextMeshProUGUI>().text = item.review;
                temp.transform.Find("Rating").gameObject.GetComponent<TextMeshProUGUI>().text = (Mathf.Floor(item.rating * 10) * 0.1f).ToString();
            }
        }
        reviewAvr = (Mathf.Floor(reviewAvr/reviewCnt * 10) * 0.1f);
        reviewAvrText.text = reviewAvr.ToString();
    }
    private ReviewDataList LoadData()
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
public class ReviewData
{
    public string review;
    public string shopName;
    public string userName;
    public float rating;
}
[System.Serializable]
public class ReviewDataList
{
    public List<ReviewData> reviews = new List<ReviewData>();
}
