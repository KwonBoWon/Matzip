using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public string id;
    public string name;
    
    public void ShopList()
    {
        SceneManager.LoadScene("ShopList");
    }
    
    public void SignUp()
    {
        SceneManager.LoadScene("SignUp");
    }
}
