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


public class ReviewManager : MonoBehaviour
{
    public UnityEngine.UI.Slider ratingSlider;
    public TextMeshProUGUI ratingText;
    public TextMeshProUGUI shopName;
    public TMP_InputField inputField;
    private MainManager mainManager;
    private float rating;

    void Start()
    {
        mainManager = MainManager.Instance;
        shopName.text = mainManager.realShopName;
    }
    public void SliderButton()
    {
        rating = ratingSlider.value; 
        ratingText.text = (Mathf.Floor(rating * 10) * 0.1f).ToString(); // 소수점 둘째자리에서 버림

    }
    public void SaveToJson()
    {
        string inputString = inputField.text;
        JSONObject data = new JSONObject();
        data["review"] = inputString;
        data["shopName"] = mainManager.shopName;
        data["userName"] = mainManager.userName;
        data["rating"] = rating;
        string jsonString = data.ToString();
        //File.WriteAllText(Path.Combine(Application.dataPath, "reviewData.json"), jsonString);
        File.AppendAllText(Path.Combine(Application.dataPath, "reviewData.json"), jsonString);

        SceneManager.LoadScene("ShopInfo");
    }
}
