using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using NativeGalleryNamespace;
using TMPro;  // TextMeshPro namespace

public class ReviewUploadManager : MonoBehaviour
{


    public Button loadImageBtn;
    public Button saveJsonBtn;
    public TMP_InputField inputField;
    public Image displayImage;
    public StarRating starRating;
    private Texture2D loadedImage;
    private string imagePath;
    private MainManager mainManager;

    public class StarRating : MonoBehaviour
    {
        public List<Toggle> stars = new List<Toggle>();

        public float GetRating()
        {
            for (int i = 0; i < stars.Count; i++)
            {
                if (stars[i].isOn)
                {
                    return (i + 1) * 0.5f; // 별점은 0.5의 배수이므로 i에 1을 더하고 0.5를 곱합니다
                }
            }

            return 0f; // 별점이 선택되지 않았다면 0을 반환합니다
        }
    }

    void Start()
    {
        loadImageBtn.onClick.AddListener(LoadImage);
        saveJsonBtn.onClick.AddListener(SaveToJson);

    }

    void LoadImage()
    {
        if (NativeGallery.IsMediaPickerBusy())
            return;

        PickImage(512);
    }

    private void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                imagePath = path;
                loadedImage = NativeGallery.LoadImageAtPath(path, maxSize);
                if (loadedImage == null)
                {
                    Debug.Log("Could not load image at " + path);
                    return;
                }

                Sprite sprite = Sprite.Create(loadedImage, new Rect(0, 0, loadedImage.width, loadedImage.height), new Vector2(0.5f, 0.5f));
                displayImage.sprite = sprite;
            }
        }, "Select an image", "image/*");

        Debug.Log("Permission result: " + permission);
    }

    void SaveToJson()
    {
        string inputString = inputField.text;
        //float rating = starRating.GetRating();

        JSONObject data = new JSONObject();
        data["input_string"] = inputString;
        data["image_path"] = imagePath;
        //data["star_rating"] = rating;

        string jsonString = data.ToString();
        System.IO.File.WriteAllText(Application.persistentDataPath + "/data.json", jsonString);

        //Debug.Log("Data saved to " + Application.persistentDataPath + "/"+  +".json");

        SceneManager.LoadScene("ShopInfo");
    }
}
