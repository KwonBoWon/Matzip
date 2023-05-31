using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GetButtonName()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        MainManager.Instance.shopName = buttonName;
        SceneManager.LoadScene("ShopInfo");
    }
    public void WriteReview()
    {
        SceneManager.LoadScene("Review2");
    }
}
