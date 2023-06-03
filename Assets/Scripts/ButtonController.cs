using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // shopList 에서 식당 클릭 시 실행되는 메소드
    public void GetButtonName()
    {
        // 현재 클릭된 버튼을 받아 MainManager로 넘긴다.
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        MainManager.Instance.shopName = buttonName;
        SceneManager.LoadScene("ShopInfo");
    }
    // Review 씬으로 넘기는 메소드
    public void WriteReview()
    {
        SceneManager.LoadScene("Review2");
    }
}
