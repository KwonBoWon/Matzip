using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public void GetButtonName()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        MainManager.Instance.shopName = buttonName;
        Debug.Log(buttonName);
        // 씬 이동
    }
}
