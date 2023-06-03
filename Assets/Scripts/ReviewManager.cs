using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class ReviewManager : MonoBehaviour
{
    public UnityEngine.UI.Slider ratingSlider;
    public TextMeshProUGUI ratingText;
    public TextMeshProUGUI shopName;
    public TMP_InputField inputField;
    private MainManager mainManager;
    private string path;
    private float rating;
    private ReviewData review;

    void Start()
    {
        mainManager = MainManager.Instance;
        shopName.text = mainManager.realShopName;
        review = new ReviewData();
        review.userName = mainManager.userName;
        review.shopName = mainManager.shopName;
        path = Path.Combine(Application.dataPath, "reviewData.json");
    }
    public void SliderButton()
    {
        rating = ratingSlider.value; 
        ratingText.text = (Mathf.Floor(rating * 10) * 0.1f).ToString(); 
        review.rating = rating;
    }
    public void InputFiled(){
        review.review = inputField.text;
    }


    public void Write(){
        ReviewDataList existingData = LoadData();
        Debug.Log(existingData);
        existingData.reviews.Add(review);
        SaveData(existingData);
        SceneManager.LoadScene("ShopInfo");
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
    public void SaveData(ReviewDataList data)
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
}
