using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour {

    public GameObject backButton;
    public SwiftyAccountManager accountManager;
    
    [Header("Panel")]
    public GameObject panelUserCanvas;
    public GameObject panelLoggedIn;
    public GameObject panelLogin;
    public GameObject panelRegister;

    [Header("Login")]
    public GameObject loginName;
    public GameObject loginPassword;
    public GameObject loginButton;

    public GameObject LoginRegisterButton;

    [Header("Register")]
    public GameObject RegisterName;
    public GameObject RegisterPassword;
    public GameObject RegisterRPassword;
    public GameObject RegisterButton;

    private void Start()
    {
        AllFalse();
    }

    public void HideUserCanvas()
    {
        AllFalse();
    }

    public void ShowUserCanvas()
    {
        AllFalse();
        if (accountManager.isLoggedin)
        {
            panelUserCanvas.SetActive(true);
            panelLoggedIn.SetActive(true);
        }
        else
        {
            panelUserCanvas.SetActive(true);
            panelLogin.SetActive(true);
        }
    }

    public void Login()
    {
        string name = loginName.GetComponent<InputField>().text;
        string password = loginPassword.GetComponent<InputField>().text;
        StartCoroutine(accountManager.Login(name,password));
    }

    private void AllFalse()
    {
        panelLoggedIn.SetActive(false);
        panelLogin.SetActive(false);
        panelRegister.SetActive(false);
        panelUserCanvas.SetActive(false);
    }


    
}
