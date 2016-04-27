using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.scripts;
using UnityEngine.SceneManagement;

public class FacebookController : MonoBehaviour {

    public GameObject loadingPanel;
    List<string> perms;
    public Image pic;
	void Start () {
        GameSettings.user = new User();
        perms = new List<string>();
        perms.Add("public_profile");
        perms.Add("email");
        loadingPanel.SetActive(false);
	    if(!FB.IsInitialized)
        {
            FB.Init(OnInit, OnHideUnity);
        }
	}

    void OnInit()
    {

    }
    void OnHideUnity(bool gameIsShow)
    {
        if (gameIsShow)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
	
    public void Login()
    {
        FB.LogInWithReadPermissions(perms, OnLoginComplete);
    }
    void OnLoginComplete(IResult result)
    {
        if (FB.IsLoggedIn)
        {
            loadingPanel.SetActive(true);
            FB.API("/me?fields=first_name,last_name,email", HttpMethod.GET, OnDataComplete);
            FB.API("/me/picture?type=square&width=128&height=128", HttpMethod.GET, OnPicComplete);
        }
        else
        {
            print("cancelar");
        }
    }
    void OnDataComplete(IResult result)
    {
        print(result.ResultDictionary["first_name"]);
        GameSettings.user.first_name = (string)result.ResultDictionary["first_name"];
        GameSettings.user.last_name =(string) (result.ResultDictionary)["last_name"];
    }
    void OnPicComplete(IGraphResult result)
    {

        GameSettings.user.profile_pic = result.Texture;
        SceneManager.LoadScene("Game");
    }
	void Update () {
	
	}
}
