using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController : MonoBehaviour {

    public UserController uc;

    public void OnPlayerButton()
    {
        uc.ShowUserCanvas();
    }

    public  void OnLoginButton()
    {
        uc.Login();
    }

    public  void OnLogOutButton()
    {

    }

    public  void OnBackButton()
    {
        uc.HideUserCanvas();
    }

    public  void OnLoginRegisterButton()
    {

    }

    public  void OnRegisterButton()
    {

    }

}
